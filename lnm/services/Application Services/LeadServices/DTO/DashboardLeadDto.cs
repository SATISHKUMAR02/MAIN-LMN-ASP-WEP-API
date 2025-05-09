using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace services.Application_Services.LeadServices.DTO
{
    public class DashboardLeadDto
    {
        public int institutiton_id { get; set; }

        public string institutiton_name { get; set; }

        public string institution_type { get; set; }

        public string assign_connector { get; set; }

        public string institution_status { get; set; }

        public string mou_status { get; set; }
    }
}
