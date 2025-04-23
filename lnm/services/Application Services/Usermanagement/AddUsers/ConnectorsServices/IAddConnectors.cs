using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using model;
using services.Application_Services.LeadServices.DTO;
using services.Application_Services.Usermanagement.AddUsers.Connectors.DTO;
using services.Application_Services.Usermanagement.Connectors.DTO;

namespace services.Application_Services.Usermanagement.AddUsers.Connectors
{
    public interface IAddConnectors
    {
        Task<CommonResponse<AddConnectordto>> CreateConnectorAsync(AddConnectordto dto);

        Task<CommonResponse<List<Connectordto>>> GetAllConnectorAsync();

        Task<CommonResponse<AddConnectordto>> GetConnectorByIdAsync(int id); // this is for the getting the details for updation


        Task<CommonResponse<AddConnectordto>> UpdateConnectorAsync(AddConnectordto dto);

        Task<CommonResponse<object>> DeleteConnectorAsync(int id);

    }
}
