using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace services.Application_Services.LeadServices.Meetings.DTO
{
    public class ScheduleMeetingdto
    {
        
        
        public DateOnly date {  get; set; }

        public TimeOnly time { get; set; }

        //public int typ { get; set; } 

        public int assignedto { get; set; }

        public string descritpion { get; set; } 

        

       

    }
}
