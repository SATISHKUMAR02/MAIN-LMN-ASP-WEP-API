using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace services.Application_Services.Usermanagement.Connectors.DTO
{
    public class Telecallerdto
    {
        public int telecallerId { get; set; }

        public string telecallerName { get; set; }

        public DateOnly joining_date { get; set; }

        public string phonenumber { get; set; }

        public string email { get; set; }

        public bool status { get; set; }

        public int createdBy { get; set; }
    }
}
