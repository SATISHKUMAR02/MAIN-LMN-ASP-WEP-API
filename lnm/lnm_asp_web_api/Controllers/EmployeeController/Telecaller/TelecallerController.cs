using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using model;
using services.Application_Services.LeadServices.DTO;
using services.Application_Services.Usermanagement.AddUsers.Connectors.DTO;
using services.Application_Services.Usermanagement.AddUsers.TelecallersServices;
using services.Application_Services.Usermanagement.AddUsers.TelecallersServices.DTO;
using services.Application_Services.Usermanagement.Connectors.DTO;

namespace lnm_asp_web_api.Controllers.EmployeeController.Telecaller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TelecallerController : ControllerBase
    {
        private readonly IAddTelecaller _addTelecaller;
        public TelecallerController(IAddTelecaller addTelecaller)
        {
            _addTelecaller = addTelecaller;
        }
        [HttpPost]
        [Route("CreateNewTelecaller")] // =============================================== for adding telecallers only by Admin
        [Authorize(Roles = "3")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<CommonResponse<AddTelecallerdto>>> CreateUser([FromBody] AddTelecallerdto dto)
        {
            try
            {
                var connector = await _addTelecaller.CreateTelecallerAsync(dto);

                return StatusCode(connector.StatusCode, connector);

            }
            catch (Exception ex)
            {

                return BadRequest(new CommonResponse<AddTelecallerdto>(false, ex.Message, 400, null));
            }
        }

        [HttpGet]
        [Route("GetAllTelecaller")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<CommonResponse<Telecallerdto>>> GetAllTelecallers()
        {
            try
            {
                var telecallers = await _addTelecaller.GetAllTelecallerAsync();
                return StatusCode(telecallers.StatusCode, telecallers);
            }
            catch (Exception ex)
            {
                return BadRequest(new CommonResponse<Telecallerdto>(false, ex.Message, 404, null));
            }

        }

        [HttpGet]
        [Route("GetTelecallerById/{id:int}")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<CommonResponse<AddTelecallerdto>>> GetTelecallersById(int id)
        {
            try
            {
                var telecaller = await _addTelecaller.GetTelecallerByIdAsync(id);
                return StatusCode(telecaller.StatusCode, telecaller);
            }
            catch (Exception ex)
            {
                return BadRequest(new CommonResponse<AddTelecallerdto>(false, ex.Message, 404, null));
            }

        }

        [HttpPut]
        [Route("UpdateTelecaller/{id:int}")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<CommonResponse<AddTelecallerdto>>> UpdateTelecaller(int id, [FromBody] AddTelecallerdto dto)
        {

            try
            {
                if (dto == null || dto.telecaller_id != id)
                {
                    return BadRequest(new CommonResponse<AddTelecallerdto>(false, "invalid credentials", 404, null));
                }

                var existingTelecaller = await _addTelecaller.UpdateTelecallerAsync(dto);
                return StatusCode(existingTelecaller.StatusCode, existingTelecaller);
            }
            catch (Exception ex)
            {
                return BadRequest(new CommonResponse<AddTelecallerdto>(false, ex.Message, 404, null));


            }

        }

        [HttpDelete]
        [Route("DeleteTelecaller/{id:int}")]
        [Authorize(Roles = "3")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]

        public async Task<ActionResult<CommonResponse<object>>> DeleteTelecaller(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest(new CommonResponse<object>(false, "invalid credentials", 404, null));
                }
                var telecaller = await _addTelecaller.DeleteTelecallerAsync(id);
                return StatusCode(telecaller.StatusCode, telecaller);
            }
            catch (Exception ex)
            {
                return BadRequest(new CommonResponse<object>(false, ex.Message, 404, null));
            }

        }
    }
}
