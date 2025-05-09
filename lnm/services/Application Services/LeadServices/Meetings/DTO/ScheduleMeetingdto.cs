using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace services.Application_Services.LeadServices.Meetings.DTO
{
    public class ScheduleMeetingdto
    {
        public int meeting_id {  get; set; }

        public int institution_id {  get; set; }
        
        public DateOnly date {  get; set; }

        public TimeOnly time { get; set; }

        public string type { get; set; } 

        public string descritpion { get; set; } 

        public int created_by { get; set; } // gives the user id of the user who created it

        public bool meeting_conducted { get; set; }  // yes or no

        public string meeting_outcome { get; set; }  // interested / not interest / pending

       

    }
}
