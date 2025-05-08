using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model;
using services.Application_Services.Usermanagement.AddUsers.Connectors.DTO;
using services.Application_Services.Usermanagement.AddUsers.TelecallersServices.DTO;
using services.Application_Services.Usermanagement.Connectors.DTO;

namespace services.Application_Services.Usermanagement.AddUsers.TelecallersServices
{
    public interface IAddTelecaller
    {
        Task<CommonResponse<AddTelecallerdto>> CreateTelecallerAsync(AddTelecallerdto dto);

        Task<CommonResponse<List<Telecallerdto>>> GetAllTelecallerAsync();

        Task<CommonResponse<AddTelecallerdto>> GetTelecallerByIdAsync(int id); // this is for the getting the details for updation


        Task<CommonResponse<AddTelecallerdto>> UpdateTelecallerAsync(AddTelecallerdto dto);

        Task<CommonResponse<object>> DeleteTelecallerAsync(int id);

        Task<CommonResponse<object>> DeleteTempTelecallerAsync(int id);
    }
}
