using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using model;
using services.Application_Services.Usermanagement.AddUsers.Connectors;
using services.Application_Services.Usermanagement.AddUsers.ConnectorsServices.DTO;

namespace lnm_asp_web_api.Controllers.EmployeeController.SubConnector
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Connector")]

    public class SubConnectorController : ControllerBase 
    {
        private readonly IAddConnectors _addConnectors;
        public SubConnectorController(IAddConnectors addConnectors)
        {
            _addConnectors = addConnectors;
        }
        [HttpPost]
        [Route("CreateNewSubConnector")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<CommonResponse<AddSubConnectordto>>> CreateSubConnector([FromBody] AddSubConnectordto dto)
        {
            try
            {
                var subconnector = await _addConnectors.CreateSubConnectorAsync(dto);

                return StatusCode(subconnector.StatusCode, subconnector);
            }
            catch (Exception ex)
            {

                return BadRequest(new CommonResponse<AddSubConnectordto>(false, ex.Message, 400, null));
            }
        }

        [HttpPut]
        [Route("UpdateSubConnector/{id:int}")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<CommonResponse<AddSubConnectordto>>> UpdateSubConnector(int id, [FromBody] AddSubConnectordto dto)
        {
            try
            {
                if (dto == null || dto.employee_id != id)
                {
                    return BadRequest(new CommonResponse<AddSubConnectordto>(false, "invalid input credentials", 400, null));
                }
                var subconnector = await _addConnectors.UpdateSubConnectorAsync(dto);

                return StatusCode(subconnector.StatusCode, subconnector);
            }
            catch (Exception ex)
            {

                return BadRequest(new CommonResponse<AddSubConnectordto>(false, ex.Message, 400, null));
            }
        }

        [HttpDelete]
        [Route("DeleteSubConnector/{id:int}")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<CommonResponse<object>>> DeleteSubConnector(int id)
        {
            try
            {
                if (id < 0)
                {
                    return BadRequest(new CommonResponse<object>(false,"invalid input details",400,null));
                }
                var subconnector = await _addConnectors.DeleteSubConnectorAsync(id);
               
                return StatusCode(subconnector.StatusCode,subconnector);
            }
            catch (Exception ex)
            {
                return BadRequest(new CommonResponse<object>(false, ex.Message, 404, null));

            }
        }

        [HttpGet]
        [Route("GetAllSubConnector")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<CommonResponse<SubConnectordto>>> GetAllSubConnector()
        {
            try
            {
                var subconnectors = await _addConnectors.GetAllConnectorAsync();
               
                return StatusCode(subconnectors.StatusCode,subconnectors);
            }
            catch (Exception ex)
            {
                return BadRequest(new CommonResponse<SubConnectordto>(false,ex.Message,404,null));
            }
        }

        [HttpGet]
        [Route("GetSubConnectorById/{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<CommonResponse<AddSubConnectordto>>> GetSubConnectorById(int id)
        {
            try
            {
                var subconnector = await _addConnectors.GetConnectorByIdAsync(id);

                return StatusCode(subconnector.StatusCode, subconnector);
            }
            catch (Exception ex)
            {
                return BadRequest(new CommonResponse<AddSubConnectordto>(false, ex.Message, 404, null));
            }
        }

    }
}
