using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace services.Application_Services.LeadServices.Meetings.DTO
{
    public class UpdateMeetingdto

    {

        public bool meeting_conducted {  get; set; }

        public string meeting_outcome { get; set; } // interested , not interested , discussion rescheduled

        public string description { get; set; }  // description about the meeting 
         

    }
}
