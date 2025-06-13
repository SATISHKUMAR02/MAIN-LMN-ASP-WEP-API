using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace services.Application_Services.LeadServices.Meetings.DTO
{
    public class Historydto
    {
        public int meeting_Id { get; set; }

        public DateOnly date {  get; set; }

        public string outcome { get; set; }

        public TimeOnly time { get; set; }

        public int updated_by { get; set; }

        public string description { get; set; }

    }
}
