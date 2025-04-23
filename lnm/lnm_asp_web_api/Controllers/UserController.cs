using Microsoft.AspNetCore.Mvc;
using services.Application_Services.User_Service;
using static System.Net.WebRequestMethods;

namespace lnm_asp_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("UserLogin")]
        public async Task<IActionResult> UserLogin(string contact_number, string otp)
        {
            try
            {
                var response = await _userService.Login(contact_number, otp);
                return StatusCode(response.StatusCode, response);

            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        [HttpGet("SendOTP")]
        public async Task<IActionResult> SendOTP(string registered_mnumber)
        {
            try
            {
                var response = await _userService.SendOTP(registered_mnumber);
                return StatusCode(response.StatusCode, response);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
