using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model;
using services.Application_Services.LeadServices.Meetings.DTO;

namespace services.Application_Services.LeadServices.Meetings
{
    public interface IScheduleMeetingCallback
    {
        // for meetings only CRUD

        Task<CommonResponse<ScheduleMeetingdto>> CreateMeetingAsync(ScheduleMeetingdto dto);

        Task<CommonResponse<ScheduleMeetingdto>> GetMeetingAsync(ScheduleMeetingdto dto);

        Task<CommonResponse<ScheduleMeetingdto>> UpdateMeetingAsync(ScheduleMeetingdto dto);

        Task<CommonResponse<object>> DeleteMeetingAsync(int id);


        // for callbacks only CRUD
        Task<CommonResponse<ScheduleCallbackdto>> CreateCallbackAsync(ScheduleCallbackdto dto);

        Task<CommonResponse<ScheduleCallbackdto>> GetCallbackAsync(ScheduleCallbackdto dto);

        Task<CommonResponse<ScheduleCallbackdto>> UpdateCallbackAsync(ScheduleCallbackdto dto);

        Task<CommonResponse<object>> DeleteCallbackAsync(int id);


    }

}

/*
 [Key]
        public int MmMeetingId { get; set; }

        public int MmInstitutionId { get; set; }

        public string? MmMeetingDescritpion { get; set; }

        public int MmCreatedBy { get; set; }

        public DateTime? MmCreatedDate { get; set; }

        public int? MmUpdatedBy { get; set; }

        public string? MmInstitutionResponded { get; set; }

        public DateTime MmUpdatedDate { get; set; }

        public string? MmInstitutionAddress { get; set; }

        public TimeOnly? MmMeetingTime { get; set; }
        // creating only one table for both meeting and callback , and it is differentiated by the meeting type (Meeting/Callback)
        public string? MmMeetingType { get; set; }
        //========================================================================================
        public string? MmMeetingStatus { get; set; }
 * /