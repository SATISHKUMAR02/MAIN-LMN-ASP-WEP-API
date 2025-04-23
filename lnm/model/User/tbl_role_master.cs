using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace services.User
{
    public class tbl_role_master
    {
        [Key]
        public int rm_id { get; set; }
        public string? rm_name_e { get; set; }
        public string? rm_name_k { get; set; }
        public bool? rm_is_active { get; set; }
        public int? rm_created_by { get; set; }
        public int? rm_updated_by { get; set; }
        public DateTime? rm_created_date { get; set; }
        public DateTime? rm_updated_date { get; set; }
     
    }
}
