using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace services.Application_Services.LeadServices.Meetings.DTO
{
    public class StatusUpdatedto
    {
        public int institutionId {  get; set; }

        public string institutionName { get; set; }

        public DateOnly date {  get; set; }

        public TimeOnly time { get; set; }

        public string updated_by { get; set; }

        public string description { get; set; }
    }
}
