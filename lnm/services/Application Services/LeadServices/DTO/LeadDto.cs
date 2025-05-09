using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace services.Application_Services.LeadServices.DTO
{
    public class LeadDto
    {
        public int institution_id { get; set; }
        public string institution_type { get; set; } 
        public string Address { get; set; }
        public string institution_name { get; set; }
        public string principal_name { get; set; }
        //public string institution_status { get; set; }  // pending interested not-intrested
        public string principal_contact { get; set; }
        public string principal_email { get; set; }
        public int student_strength { get; set; }
        public string other_name { get; set; }
        public string other_designation { get; set; }
        public string other_contact { get; set; }
        public string other_email { get; set; }
        //public string mou_status { get; set; }  // pending approved rejected
        public string assigned_connector { get; set; } // storing all the sub connectors here
        public string created_by { get; set; }

    }
}
