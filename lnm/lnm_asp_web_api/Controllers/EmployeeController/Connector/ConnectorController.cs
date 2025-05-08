using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using model;
using services.Application_Services.LeadServices.DTO;
using services.Application_Services.Usermanagement.AddUsers.Connectors;
using services.Application_Services.Usermanagement.AddUsers.Connectors.DTO;
using services.Application_Services.Usermanagement.AddUsers.TelecallersServices;
using services.Application_Services.Usermanagement.Connectors.DTO;

namespace lnm_asp_web_api.Controllers.EmployeeController.Connector
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ConnectorController : ControllerBase
    {
        private readonly IAddConnectors _addConnectors;

        public ConnectorController(IAddConnectors connectors)
        {
            _addConnectors = connectors;

        }
        [HttpPost]
        [Authorize(Roles ="3")]
        [Route("CreateNewConnector")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<ActionResult<CommonResponse<AddConnectordto>>> CreateUser([FromBody] AddConnectordto dto)
        {
            try
            {
                var connector = await _addConnectors.CreateConnectorAsync(dto);
                return StatusCode(connector.StatusCode, connector);
            }
            catch (Exception ex)
            {
                return BadRequest(new CommonResponse<AddConnectordto>(false, ex.Message, 400, null));
            }
        }

        [HttpGet]
        [Route("GetAllConnectors")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<CommonResponse<Connectordto>>> GetAllConnector()
        {
            try
            {
                //var roleid = 2;
                var connectors = await _addConnectors.GetAllConnectorAsync();
                return StatusCode(connectors.StatusCode, connectors);
            }
            catch (Exception ex)
            {
                return BadRequest(new CommonResponse<Connectordto>(false, ex.Message, 404, null));
            }


        }

        [HttpGet]
        [Route("GetConnectorMOU/{mouid:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]

        public async Task<ActionResult<CommonResponse<object>>> GetConnectorMou(int mouid)
        {
            try
            {
                var mou = await _addConnectors.GetConnectorMouByIdAsync(mouid);
                return StatusCode(mou.StatusCode, mou);
                
            }
            catch (Exception ex)
            {
                return BadRequest(new CommonResponse<object>(false, ex.Message, 404, null));
            }
        }

        [HttpGet]
        [Route("GetConnectorById/{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<CommonResponse<AddConnectordto>>> GetConnectorByIds(int id)
        {
            try
            {
                var connector = await _addConnectors.GetConnectorByIdAsync(id);
                return StatusCode(connector.StatusCode, connector);
            }
            catch (Exception ex)
            {

                return BadRequest(new CommonResponse<AddConnectordto>(false, ex.Message, 404, null));
            }
        }


        //[HttpGet]
        //[Route("GetConnectorByName/{name:alpha}")]
        //[ProducesResponseType(200)]
        //[ProducesResponseType(400)]
        //[ProducesResponseType(401)]
        //[ProducesResponseType(404)]
        //public async Task<ActionResult<CommonResponse<AddConnectordto>>> GetConnectorByIds(string name)
        //{
        //    try
        //    {
        //        var connector = await _addConnectors.GetConnectorByNameAsync(id);
        //        return StatusCode(connector.StatusCode, connector);
        //    }
        //    catch (Exception ex)
        //    {

        //        return BadRequest(new CommonResponse<AddConnectordto>(false, ex.Message, 404, null));
        //    }
        //}

        [HttpPut]
        [Route("UpdateConnector/{id:int}")]
        [Authorize(Roles ="3")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]

        public async Task<ActionResult<CommonResponse<AddConnectordto>>> UpdateConnector(int id, [FromBody] AddConnectordto dto)
        {
            try
            {
                if (dto == null || dto.connector_id != id)
                {
                    return BadRequest(new CommonResponse<AddConnectordto>(false, "invalid credentials", 404, null));
                }
                var existingConnector = await _addConnectors.UpdateConnectorAsync(dto);
                return StatusCode(existingConnector.StatusCode, existingConnector);
            }
            catch (Exception ex)
            {
                return BadRequest(new CommonResponse<AddConnectordto>(false, ex.Message, 404, null));

            }
        }

        [HttpDelete]
        [Route("DeleteConnector/{id:int}")]
        [Authorize(Roles ="3")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]

        [ProducesResponseType(404)]

        public async Task<ActionResult<CommonResponse<object>>> DeleteConnector(int id)
        {
            try
            {
                if (id < 0)
                {
                    return BadRequest(new CommonResponse<object>(false, "invalild id of connector", 404, null));
                }
                var connector = await _addConnectors.DeleteConnectorAsync(id);
                return StatusCode(connector.StatusCode, connector);
            }
            catch (Exception ex)
            {
                return BadRequest(new CommonResponse<object>(false, ex.Message, 404, null));

            }


        }

    }
}
