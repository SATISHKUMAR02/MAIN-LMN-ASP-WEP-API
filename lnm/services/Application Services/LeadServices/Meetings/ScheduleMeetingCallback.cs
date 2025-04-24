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
            TblMeetingsMaster 
        }

       

        Task<CommonResponse<object>> IScheduleMeetingCallback.DeleteMeetingAsync(int id)
        {
            throw new NotImplementedException();
        }
        Task<CommonResponse<ScheduleMeetingdto>> IScheduleMeetingCallback.UpdateMeetingAsync(ScheduleMeetingdto dto)
        {
            throw new NotImplementedException();
        }
        Task<CommonResponse<ScheduleMeetingdto>> IScheduleMeetingCallback.GetMeetingAsync(ScheduleMeetingdto dto)
        {
            throw new NotImplementedException();
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
