using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace services.Application_Services.LeadServices.Meetings.DTO
{
    public class ScheduleMeetingdto
    {
        public int institution_id {  get; set; }
        
        public DateOnly date {  get; set; }

        public TimeOnly time { get; set; }

        public string type { get; set; } = "meeting";

        public string descritpion { get; set; } 

        public string created_by { get; set; }

        
    }
}
