using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model;
using model.Institution;
using services.Application_Services.LeadServices.Meetings.DTO;

namespace services.Application_Services.LeadServices.Meetings
{
    public interface IScheduleMeetingCallback
    {
        // for meetings only CRUD

        Task<CommonResponse<ScheduleMeetingdto>> CreateMeetingAsync(ScheduleMeetingdto dto);

        Task<CommonResponse<List<MeetingCallbackdashdto>>> GetMeetingAsync();


        Task<CommonResponse<ScheduleMeetingdto>> UpdateMeetingAsync(ScheduleMeetingdto dto);

        Task<CommonResponse<object>> DeleteMeetingAsync(int meeting_id, int institution_id);

        // this is common  for history dashboard  only get operation

        Task<CommonResponse<List<MeetingCallbackdashdto>>> GetAllMeetingCallbackAsync();

        Task<CommonResponse<ScheduleMeetingdto>> GetMeetingByIdAsync(int id);

        Task<CommonResponse<StatusUpdatedto>> CreateStatusUpdateAsync(StatusUpdatedto dto);

        // for callbacks only CRUD
        Task<CommonResponse<ScheduleCallbackdto>> CreateCallbackAsync(ScheduleCallbackdto dto);

        Task<CommonResponse<ScheduleCallbackdto>> GetCallbackAsync();

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

        public bool MmMeetingConducted { get; set; }

        public string MmmeetingOutcome {get;set;} 

(from a in _context.tbl_user_login_details
                                join b in _context.tbl_employee_master on a.uld_employee_id equals b.em_id
                                join c in _context.tbl_role_master on b.em_role_id equals c.rm_id
                                where a.uld_id == valid_otp.uld_id
                                select new UserDetails
                                {
                                    user_id = b.em_id,
                                    user_name = b.em_name_e,
                                    user_contact_number = b.em_contact_number,
                                    user_role_id = (int)b.em_role_id,
                                    user_role = c.rm_name_e,
                                    token = token,
                                }).FirstOrDefault();
 */