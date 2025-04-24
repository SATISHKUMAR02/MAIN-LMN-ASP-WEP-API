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
            await _repository.CreateAsync(meeting);
            meeting.MmMeetingStatus = "open";
            meeting.MmmeetingOutcome = "pending";
            meeting.MmCreatedDate = DateTime.Now;
            meeting.MmInstitutionResponded = "yes";

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
            await _repository.DeleteAsync(existingMeeting);
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

            var meetingToUpdate = _mapper.Map<TblMeetingsMaster>(dto);

            meetingToUpdate.MmUpdatedDate = DateTime.Now;

            await _repository.UpdateAsync(meetingToUpdate);

            var response = _mapper.Map<ScheduleMeetingdto>(existingMeeting);

            return new CommonResponse<ScheduleMeetingdto>(true, "meeting updated successfully", 200, response);



        }
        public async Task<CommonResponse<MeetingCallbackdashdto>> GetMeetingAsync()
        {
            var meetings = await _repository.GetAllAsync();
            var data = _mapper.Map<MeetingCallbackdashdto>(meetings);
            return new CommonResponse<List<MeetingCallbackdashdto>>(true,"data fetched successfully",200,data);
        }

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

        

























        //============================================================================///========================

        Task<CommonResponse<ScheduleCallbackdto>> IScheduleMeetingCallback.CreateCallbackAsync(ScheduleCallbackdto dto)
        {
            throw new NotImplementedException();
        }
        Task<CommonResponse<ScheduleCallbackdto>> IScheduleMeetingCallback.GetCallbackAsync(ScheduleCallbackdto dto)
        {
            throw new NotImplementedException();
        }
        Task<CommonResponse<object>> IScheduleMeetingCallback.DeleteCallbackAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<CommonResponse<ScheduleCallbackdto>> IScheduleMeetingCallback.UpdateCallbackAsync(ScheduleCallbackdto dto)
        {
            throw new NotImplementedException();
        }

       
    }
}
