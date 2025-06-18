using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace services.Application_Services.ActivityServices.DTO
{
    public class InstitutionActivitydto
        // this is for already selected activites from the school
    {
        public int ActivityId { get; set; }
        public int InstitutionId { get; set; }
        public string ActivityName { get; set; }

        public int  studentStrength { get; set; }

        public DateOnly DateOfEvent { get; set; }

        public string eventVenue { get; set; }

        public int studentParticipating { get; set; }

        public int NoOfDaysEvent { get; set; }
    }
}
