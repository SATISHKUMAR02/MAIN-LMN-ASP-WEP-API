using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace services.Application_Services.Usermanagement.Connectors.DTO
{
    public class Connectordto
    {
        public int connectorId { get; set; };

        public string connectorName { get; set; }

        public DateTime joining_date { get; set; }

        public bool status { get;set; }

        public string view {  get; set; }


    }
}
