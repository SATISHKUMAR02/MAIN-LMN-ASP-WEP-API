using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model.User
{
    public class tbl_user_login_details
    {
        [Key]
        public int uld_id { get; set; }
        public string? uld_contact_number { get; set; }
        public string? uld_otp { get; set; }
        public DateTime? uld_otp_time { get; set; }
        public int? uld_employee_id { get; set; }
        public string? uld_password { get; set; }
        public bool? uld_is_active { get; set; }
        public int? uld_created_by { get; set; }
        public int? uld_updated_by { get; set; }
        public DateTime? uld_created_date { get; set; }
        public DateTime? uld_updated_date { get; set; }

        public tbl_employee_master Employee {  get; set; }  // establishing bw login and employee with employeeId
     
    }
}
