using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model;
using services.Application_Services.LeadServices.Meetings.DTO;

namespace services.Application_Services.LeadServices.History
{
    public interface IHistoryServices
    {
        Task<CommonResponse<List<Historydto>>> GetAllHistoryAsync();

    }
}
