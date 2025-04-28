using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace services.Application_Services.Usermanagement.AddUsers.ConnectorsServices.DTO
{
    public class AddSubConnectordto
    {
        public int employee_id {  get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Gender { get; set; } 

        public DateOnly HireDate { get; set; }

        public string phoneNo { get; set; }

        public string role { get; set; } = "Sub-Connector";

        public string created_by { get; set; } // by which connector the sub connector works 

        public DateTime updated_date { get; set; } // updated date and time

        public int created_emp_id { get; set; } // and the connector's emp_id
    }
}
