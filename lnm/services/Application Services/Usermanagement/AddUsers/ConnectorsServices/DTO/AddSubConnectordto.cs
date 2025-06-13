using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace services.Application_Services.Usermanagement.AddUsers.ConnectorsServices.DTO
{
    public class AddSubConnectordto
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Gender { get; set; } 

        public DateTime HireDate { get; set; }

        public string phoneNo { get; set; }

        public DateOnly dob { get; set; } 



        //public int created_emp_id { get; set; } // and the connector's emp_id
    }
}
