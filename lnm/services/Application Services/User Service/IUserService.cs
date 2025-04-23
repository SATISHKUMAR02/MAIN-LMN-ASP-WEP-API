using model;
using services.Application_Services.User_Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace services.Application_Services.User_Service
{
    public interface IUserService
    {
        Task<CommonResponse<UserDetails>> Login(string contact_number, string otp);
        Task<CommonResponse<object>> SendOTP(string registered_mnumber);
    }
}
