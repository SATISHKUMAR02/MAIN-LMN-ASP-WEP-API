using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model;
using services.Application_Services.MouServices.DTO;
using services.Application_Services.Usermanagement.Connectors.DTO;

namespace services.Application_Services.MouServices.TelecallerServices
{
    public interface IInstitutionService
    {
        Task<CommonResponse<List<Institutiondto>>> GetAllInstitutitionMouAsync();

        Task<CommonResponse<object>> GetInstitutionMouByVersion(float versionno);

        Task<CommonResponse<object>> GetCurrentInstitutionMouByVersionAsync();


    }
}
