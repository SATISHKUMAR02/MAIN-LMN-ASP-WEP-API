using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model.Institution
{
    public  class TblInstitutionMaster
    {
        [Key]
        public int ImInstitutionId { get; set; }

        public string ImInstitutionType { get; set; } = null!;

        public string ImInstitutionAddress { get; set; } = null!;

        public string ImInstitutionName { get; set; } = null!;

        public int ImStudentStrength { get; set; }

        public string? ImInstitutionStatus { get; set; } // pending interested not-intersted

        public string ImPrincipalName { get; set; } = null!;

        public string ImPrincipalContact { get; set; } = null!;

        public string ImPrincipalEmail { get; set; } = null!;

        public string ImOtherName { get; set; } = null!;

        public string ImOtherDesignation { get; set; } = null!;

        public string? ImOtherEmail { get; set; }

        public string? ImOtherContact { get; set; }

        public string? ImAssignConnector { get; set; }

        public int ImCreatedBy { get; set; }

        public int? ImUpdatedBy { get; set; }

        public DateTime ImCreatedDate { get; set; }

        public DateTime? ImUpdatedDate { get; set; }

        public string? ImMouStatus { get; set; } // pending approved rejected

        public bool ImIsDeleted { get; set; }

        
    }
}
