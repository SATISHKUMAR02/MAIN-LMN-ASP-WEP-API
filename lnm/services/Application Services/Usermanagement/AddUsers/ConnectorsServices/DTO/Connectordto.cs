using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace services.Application_Services.Usermanagement.Connectors.DTO
{
    public class Connectordto
    {
        public int connectorId { get; set; }

        public string connectorName { get; set; }

        public DateTime joining_date { get; set; }

        public string phone_number { get; set; }

        public string email { get; set; }

        public bool status { get;set; }

        public string view {  get; set; } // this is for storing the MOU URL


    }
}
