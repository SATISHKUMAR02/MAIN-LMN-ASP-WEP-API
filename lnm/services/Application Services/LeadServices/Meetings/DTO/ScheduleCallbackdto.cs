using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace services.Application_Services.LeadServices.Meetings.DTO
{
    public class ScheduleCallbackdto
    {
        public int meeting_id {  get; set; }

        public int institution_id { get; set; }

        public DateOnly date { get; set; }

        public TimeOnly time { get; set; }

        public string type { get; set; } = "callback";

        public string descritpion { get; set; }

        public string created_by { get; set; }

        public bool meeting_conducted { get; set; }

        public string meeting_outcome { get; set; }
        
    }
}
