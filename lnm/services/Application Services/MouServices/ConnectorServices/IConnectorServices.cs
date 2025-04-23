using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model;
using services.Application_Services.LeadServices.DTO;
using services.Application_Services.MouServices.DTO;
using services.Application_Services.User_Service.DTO;

namespace services.Application_Services.MouServices.ConnectorServices
{
    public interface IConnectorServices
    {

        Task<CommonResponse<List<connectorDtocs>>> GetAllConnectorsMouAsync();

        Task<CommonResponse<object>> GetMouByVersion(string versionno);
    }
}
