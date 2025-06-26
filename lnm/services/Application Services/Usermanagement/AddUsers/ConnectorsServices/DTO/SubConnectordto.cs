using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace services.Application_Services.Usermanagement.AddUsers.ConnectorsServices.DTO
{
    public class SubConnectordto
    {
        public int sub_connector_id {  get; set; }

        public string sub_connector_name { get; set; }

        public DateOnly hire_Date { get; set; }

        public string Contact {  get; set; }
        
        public string email { get; set; }

        public int role { get; set; } = 4;

        public int createdby { get; set; } 


    }
}
