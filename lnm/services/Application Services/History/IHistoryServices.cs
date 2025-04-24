using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model;
using services.Application_Services.LeadServices.DTO;

namespace services.Application_Services.History
{
    public interface IHistoryServices
    {
        Task<CommonResponse<List<Meetingdto>>> GetAllMeetingsBySchoolIdAsync(int id);
    }
}
