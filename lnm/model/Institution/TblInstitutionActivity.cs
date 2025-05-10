using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model.Institution
{
    public class TblInstitutionActivity
    {
        [Key]
        public int ImInstitutionId { get; set; }

        public int ImActivityId { get; set; } 

        public string ImInstitutionType { get; set; } 

        public string ImInstitutionAddress { get; set; }

        public string ImInstitutionName { get; set; } 

        public int ImStudentStrength { get; set; }

        public string ImActivityName { get; set; }

        public string ImPrincipalName { get; set; } 

        public string ImPrincipalEmail { get; set; }

        public string ImOtherName { get; set; } 

        public string? ImOtherEmail { get; set; }

        public string? ImAssignConnector { get; set; }

        public int ImCreatedBy { get; set; }

        public int? ImUpdatedBy { get; set; }

        public DateTime ImCreatedDate { get; set; }

        public DateTime? ImUpdatedDate { get; set; }

        public DateOnly ImScheduleDate { get; set; }

        public int ImStudentParticipating {  get; set; }
        
        public int NoOfDaysEvent { get; set; }

        public string ImEventVenue { get; set; }
    }
}
