using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model;
using services.Application_Services.Usermanagement.AddUsers.Connectors.DTO;
using services.Application_Services.Usermanagement.AllUsers.DTO;

namespace services.Application_Services.Usermanagement.AllUsers
{
    public interface IAllUser
    {
        Task<CommonResponse<AllUserdto>> GetEmployeeByIdAsync(int id); 


        //Task<CommonResponse<AllUserdto>> UpdateEmployeeAsync(AllUserdto dto);

    }
}
