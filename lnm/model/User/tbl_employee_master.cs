using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model.User
{
    public class tbl_employee_master
    {
        [Key]
        public int em_id { get; set; }
        public string? em_name_e { get; set; }
        public string? em_name_k { get; set; }
        public string? em_contact_number { get; set; }
        public int? em_role_id { get; set; }
        public string? em_email_address { get; set; }
        public string? em_residencial_address { get; set; }
        public DateTime? em_joining_date { get; set; }
        public DateTime? em_end_date { get; set; }
        public bool? em_is_active { get; set; }
        public int? em_created_by { get; set; }
        public int? em_updated_by { get; set; }
        public DateTime? em_created_date { get; set; }
        public DateTime? em_updated_date { get; set; }
        
    }
}
