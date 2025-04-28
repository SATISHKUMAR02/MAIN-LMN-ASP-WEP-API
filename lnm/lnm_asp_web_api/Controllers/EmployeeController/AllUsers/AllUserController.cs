using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using model;
using services.Application_Services.LeadServices.DTO;
using services.Application_Services.Usermanagement.AllUsers;
using services.Application_Services.Usermanagement.AllUsers.DTO;

namespace lnm_asp_web_api.Controllers.EmployeeController.AllUsers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AllUserController : ControllerBase
    {
        private readonly AllUser _user;
        public AllUserController(AllUser user)
        {
            _user = user;
        }
        [HttpGet]
        //[Authorize(Roles = "Admin,Connector")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<CommonResponse<AllUserdto>>> GetEmployeeById([FromBody] int id)
        {
            try
            {
                var employee = await _user.GetEmployeeByIdAsync(id);

                return StatusCode(employee.StatusCode, employee);

            }

            catch (Exception ex)
            {

                return BadRequest(new CommonResponse<AllUserdto>(false, ex.Message, 400, null));
            }
        }
    }
}
