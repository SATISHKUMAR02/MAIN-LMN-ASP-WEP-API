using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace services.Application_Services.User_Service.DTO
{
    public class UserDetails
    {
        public int user_id { get; set; }
        public string user_name { get; set; }
        public string user_contact_number { get; set; }
        public int user_role_id { get; set; }
        public string user_role { get; set; }
        public string token { get; set; }
    }
}
