﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace services.Application_Services.Usermanagement.AddUsers.Connectors.DTO
{
    public class AddConnectordto
    {
        public int connector_id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string gender { get; set; }

        public DateOnly dateOfbirth { get; set; }
        
        public string phonenumber { get; set; }
        
        public string Email { get; set; }
        
        public DateTime hireDate  { get; set; }
        

        public DateTime updated_date { get; set; }  

        public string? ViewMou { get; set; }

       


    }
}
