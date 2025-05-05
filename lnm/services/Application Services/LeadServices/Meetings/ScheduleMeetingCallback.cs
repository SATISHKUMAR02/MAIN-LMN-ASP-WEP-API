using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using model;
using model.Institution;
using services.Application_Services.LeadServices.Meetings.DTO;
using services.Repository;

namespace services.Application_Services.LeadServices.Meetings
{
    public class ScheduleMeetingCallback : IScheduleMeetingCallback
    {

        private readonly IApplicationRepository<TblMeetingsMaster> _repository;
       
        private readonly IMapper _mapper;

        public ScheduleMeetingCallback(IApplicationRepository<TblMeetingsMaster> repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            
        }

        public async Task<CommonResponse<ScheduleMeetingdto>> CreateMeetingAsync(ScheduleMeetingdto dto)
        {
            if (dto==null)
            {
                return new CommonResponse<ScheduleMeetingdto>(false, "meeting fields are empty", 404, null);
            }

            var existingMeeting = await _repository.GetSingleAsync(u => u.MmInstitutionId == dto.institution_id
            && u.MmMeetingId == dto.meeting_id && u.MmMeetingConducted == false);

            if (existingMeeting != null)
            {
                return new CommonResponse<ScheduleMeetingdto>(false, "there is already a existing meeting scheduled", 404, null);

            }
            TblMeetingsMaster meeting = _mapper.Map<TblMeetingsMaster>(dto);
            
            meeting.MmMeetingStatus = "open";
            //meeting.MmmeetingOutcome = "pending";
            meeting.MmCreatedDate = DateTime.Now;
            
            meeting.MmInstitutionResponded = "yes";
            //meeting.MmMeetingConducted = false;
            await _repository.CreateAsync(meeting);



            var response = _mapper.Map<ScheduleMeetingdto>(meeting);
            
            return new CommonResponse<ScheduleMeetingdto>(true,"meeting scheduled successfully",200,response);
        }

      
        public async Task<CommonResponse<object>> DeleteMeetingAsync(int meeting_id,int institution_id)
        {
            if(meeting_id==0 && institution_id == 0)
            {
                return new CommonResponse<object>(false,"invalid inputs",404,null);
            } 
            var existingMeeting = await _repository.GetSingleAsync(u=>u.MmMeetingId == meeting_id && u.MmInstitutionId == institution_id );
            
            if(existingMeeting == null)
            {
                return new CommonResponse<object>(false, "meeting does not exist", 404, null);

            }
            existingMeeting.MmMeetingStatus = "close";
            
            existingMeeting.MmMeetingConducted = false;
            
            existingMeeting.MmmeetingOutcome = "pending";
            
            return new CommonResponse<object>(true,"meeting deleted successfully",200,null);

        }

        public async Task<CommonResponse<ScheduleMeetingdto>> UpdateMeetingAsync(ScheduleMeetingdto dto)
        {
            if(dto == null)
            {
                return new CommonResponse<ScheduleMeetingdto>(false, "meeting fields are empty", 404, null);

            }
            var existingMeeting = await _repository.GetSingleAsync(u=> u.MmInstitutionId == dto.institution_id && u.MmMeetingId == dto.meeting_id && u.MmMeetingConducted == false);
           
            if(existingMeeting == null)
            {
                return new CommonResponse<ScheduleMeetingdto>(false, "meeting does not exist", 404, null);
            }

            _mapper.Map(dto, existingMeeting);

            existingMeeting.MmUpdatedDate = DateTime.Now;

            await _repository.UpdateAsync(existingMeeting);

            var response = _mapper.Map<ScheduleMeetingdto>(existingMeeting);
            
            return new CommonResponse<ScheduleMeetingdto>(true, "meeting updated successfully", 200, response);



        }
        public async Task<CommonResponse<List<MeetingCallbackdashdto>>> GetMeetingAsync()
        {
            var meetings = await _repository.GetAllAsync();
           
            var data = _mapper.Map<List<MeetingCallbackdashdto>>(meetings);
            
            return new CommonResponse<List<MeetingCallbackdashdto>>(true,"data fetched successfully",200,data);
        }

        //===================================================================== for adding new  status update 


        public async Task<CommonResponse<StatusUpdatedto>> CreateStatusUpdateAsync(StatusUpdatedto dto)
        {
            if(dto == null)
            {
                return new CommonResponse<StatusUpdatedto>(false,"invalid input credentilas",404,null);
            }

            TblMeetingsMaster statusUpdate = _mapper.Map<TblMeetingsMaster>(dto);
            
            statusUpdate.MmCreatedDate = DateTime.Now;
            
            statusUpdate.MmUpdatedDate = DateTime.Now;
            
            await _repository.CreateAsync(statusUpdate);
            
            var response = _mapper.Map<StatusUpdatedto>(dto);
            
            return new CommonResponse<StatusUpdatedto>(true,"Added Status Updated",201,response);

            
        }


        //==================================================================== common for both meetings and callbacks

        public async Task<CommonResponse<ScheduleMeetingdto>> GetMeetingByIdAsync(int id)
        {
            if(id == 0)
            {
                return new CommonResponse<ScheduleMeetingdto>(false,"invalid input credentials",404,null);
            }
            var existingMeeting = await _repository.GetSingleAsync(u=>u.MmMeetingId==id);
            if(existingMeeting == null)
            {
                return new CommonResponse<ScheduleMeetingdto>(false, "meeting does not exist", 404, null);
            }
            var data = _mapper.Map<ScheduleMeetingdto>(existingMeeting);
            
            return new CommonResponse<ScheduleMeetingdto>(true,"meeting fetched successfully",200,data);

        }

        public async Task<CommonResponse<List<MeetingCallbackdashdto>>> GetAllMeetingCallbackAsync() //=====for meeting and callback dashboard
        {
            var events = await _repository.GetAllAsync();
            
            var data= _mapper.Map<List<MeetingCallbackdashdto>>(events);
            
            return new CommonResponse<List<MeetingCallbackdashdto>>(true, "all events fetched successfully", 200, data);

        }

        //==============================================================================================================================================


        //============================================================================///======================== for callbacks

        public async Task<CommonResponse<ScheduleCallbackdto>> CreateCallbackAsync(ScheduleCallbackdto dto)
        {
            if (dto == null)
            {
                return new CommonResponse<ScheduleCallbackdto>(false, "Fields are empty", 400, null);
            }

            var existingCallback = await _repository.GetSingleAsync(u =>
                u.MmInstitutionId == dto.institution_id &&
                u.MmMeetingId == dto.meeting_id &&
                u.MmMeetingConducted == false);

            if (existingCallback != null)
            {
                return new CommonResponse<ScheduleCallbackdto>(false, "There is already a callback scheduled", 409, null);
            }

            TblMeetingsMaster callback = _mapper.Map<TblMeetingsMaster>(dto);
            
            callback.MmMeetingStatus = "open";
            
            callback.MmCreatedDate = DateTime.Now;
            
            callback.MmmeetingOutcome = "pending";

            await _repository.CreateAsync(callback);

            var response = _mapper.Map<ScheduleCallbackdto>(callback);
            
            return new CommonResponse<ScheduleCallbackdto>(true, "Callback scheduled", 201, response);
        }



        public async Task<CommonResponse<ScheduleCallbackdto>> GetCallbackAsync()
        {
            var callbacks = await _repository.GetAllAsync();

            var data = _mapper.Map<ScheduleCallbackdto>(callbacks);

            if(data == null)
            {
                return new CommonResponse<ScheduleCallbackdto>(false,"no data retrieved",404,null);
            }
            return new CommonResponse<ScheduleCallbackdto>(true, "callbacks retrived ", 200, data);
        }


        public async Task<CommonResponse<object>> DeleteCallbackAsync(int id)
        {
            if(id == 0)
            {
                return new CommonResponse<object>(false,"invalid credentials",400,null);
            }
            var callToDelete = await _repository.GetSingleAsync(u=>u.MmMeetingId == id);

            if(callToDelete == null)
            {
                return new CommonResponse<object>(false,"callback does not exist",404,null);
            }
            await _repository.DeleteAsync(callToDelete);

            return new CommonResponse<object>(true,"callback deleted Successfully",200,id);   

        }

        public async Task<CommonResponse<ScheduleCallbackdto>> UpdateCallbackAsync(ScheduleCallbackdto dto)
        {
            if(dto == null)
            {
                return new CommonResponse<ScheduleCallbackdto>(false,"callback credentials empty",400,null);
            }
            var existingCallback = await _repository.GetSingleAsync(u=>u.MmMeetingId == dto.meeting_id);

            if (existingCallback == null)
            {
                return new CommonResponse<ScheduleCallbackdto>(false, "callback does not exist", 404);
            }
            existingCallback.MmUpdatedDate = DateTime.Now;

            await _repository.UpdateAsync(existingCallback);

            var response = _mapper.Map<ScheduleCallbackdto>(existingCallback);

            return new CommonResponse<ScheduleCallbackdto>(true, "callback updated successfully", 200, response);

        }

       
    }
}
