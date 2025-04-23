using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace services.Application_Services.MouServices.DTO
{
    public class connectorDtocs
    {
        public float version_no { get; set; }

        public DateTime updated_Date { get; set; }

        public string updated_by    { get; set; }

        public DateTime published_date  { get; set; }

        public string published_by { get;   set; }

        public string view {  get; set; }   
    }
}
