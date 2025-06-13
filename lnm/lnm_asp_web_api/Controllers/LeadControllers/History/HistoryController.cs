using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using model;
using services.Application_Services.LeadServices.DTO;
using services.Application_Services.LeadServices.History;
using services.Application_Services.LeadServices.Meetings.DTO;

namespace lnm_asp_web_api.Controllers.LeadControllers.History
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HistoryController : ControllerBase
    {
        private readonly IHistoryServices _historyServices;
        public HistoryController(IHistoryServices historyServices )
        {
            _historyServices = historyServices;
        }
        [HttpGet]
        [Route("GetAllHistoryByInstitution")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<CommonResponse<Historydto>>> GetAllLeads(int id)
        {
            try

            {
                var leads = await _historyServices.GetAllHistoryAsync(id);

                return StatusCode(leads.StatusCode, leads);
            }
            catch (Exception ex)
            {
                return BadRequest(new CommonResponse<Historydto>(false, ex.Message, 400, null));
            }
        }

    }
    
}
