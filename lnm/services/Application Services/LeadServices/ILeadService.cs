using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model;
using services.Application_Services.LeadServices.DTO;

namespace services.Application_Services.LeadServices
{
    public interface ILeadService
    {
        Task<CommonResponse<LeadDto>> CreateLeadAsync(LeadDto dto);

        Task<CommonResponse<LeadDto>> UpdateLeadAsync(LeadDto dto);

        Task<CommonResponse<List<DashboardLeadDto>>> GetAllLeadAsync(); // dto is different here and in its implementation

        Task<CommonResponse<List<LeadDto>>> GetleadAsync();

        Task<CommonResponse<LeadDto>> GetLeadByIdAsync(int id);

        Task<CommonResponse<LeadDto>> GetLeadByNameAsync(string institutionName);

        Task<CommonResponse<object>> DeleteLeadAsync(int id);

        //Task<CommonResponse<Meetingdto>> GetAllMeetingsBySchoolIdAsync(int id);


    }
}
