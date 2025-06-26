using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace services.Application_Services.ActivityServices.DTO
{
    public class AddInstitutionActivitydto
    {
     
        public int studentStrength { get; set; }

        public DateOnly DateOfEvent { get; set; }

        public string eventVenue { get; set; }

        public int studentParticipating { get; set; }

        public int NoOfDaysEvent { get; set; }

    }
}
