using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace services.Application_Services.LeadServices.Meetings.DTO
{
    public class MeetingCallbackdashdto
    {
        public int status_id {  get; set; }  // this is for the dashboard so we keep a common name as statusId

        public int institutionId { get; set; }

        public string institutionName {  get; set; }

        public DateOnly date {  get; set; }

        public TimeOnly time { get; set; }

        public string type { get; set; }    

        public string status { get; set; }

        public bool meeting_conducted { get; set; } 

        public string meeting_outcome { get; set; }


    }
}
