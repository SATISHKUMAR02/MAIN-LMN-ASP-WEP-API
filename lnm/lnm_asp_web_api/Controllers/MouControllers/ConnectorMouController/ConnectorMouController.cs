using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using model;
using services.Application_Services.MouServices.ConnectorServices;
using services.Application_Services.MouServices.DTO;

namespace lnm_asp_web_api.Controllers.MouControllers.ConnectorMouController
    // ========================================================================================= THIS IS JUST FOR MAINTAINING THE MOU TEMPLATES AND ITS UPGRADED VERSION
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class ConnectorMouController : ControllerBase

    {
        private readonly IConnectorServices _connectorServices;
        public ConnectorMouController(IConnectorServices connectorServices)
        {
            _connectorServices = connectorServices;
        }

        [HttpGet]
        [Route("GetAllConnectorsMous")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]

        public async Task<ActionResult<CommonResponse<connectorDtocs>>> GetAllConnectorMou()
        {
            try
            {
                var connectors = await _connectorServices.GetAllConnectorsMouAsync();
                return StatusCode(connectors.StatusCode, connectors);
            }
            catch (Exception ex) { 
            
            return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetConnectorMouByVersion/{float:alpha}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]

        public async Task<ActionResult<CommonResponse<object>>> GetConnectorMouByVersion (float version)
        {
            try
            {
                if (version <0)
                {
                    return BadRequest(new CommonResponse<object>(false, "invalid credentials", 404, null));
                }
                var mou = await _connectorServices.GetConnectorMouByVersionAsync(version);
                return StatusCode(mou.StatusCode, mou);
            }
            catch (Exception ex) { 
                return BadRequest(new CommonResponse<object>(false, ex.Message,404, null));
            }
        }

        [HttpGet]
        [Route("GetLatestConnectorMouByVersion")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]

        public async Task<ActionResult<CommonResponse<object>>> GetLatestConnectorMouByVersion()
        {
            try
            {                
                var mou = await _connectorServices.GetCurrentConnectorMouByVersionAsync();
                return StatusCode(mou.StatusCode, mou);
            }
            catch (Exception ex)
            {
                return BadRequest(new CommonResponse<object>(false, ex.Message, 404, null));
            }
        }



    }
}
