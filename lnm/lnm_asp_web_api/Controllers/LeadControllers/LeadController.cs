using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using model;
using services.Application_Services.LeadServices;
using services.Application_Services.LeadServices.DTO;

namespace lnm_asp_web_api.Controllers.LeadControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LeadController : ControllerBase
    {
        private readonly ILeadService _leadService;
        public LeadController(ILeadService leadService)
        {
            _leadService = leadService;            
        }

        [HttpPost]
        [Route("CreateLeads")]
        [Authorize(Roles = "Admin,Connector")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<CommonResponse<LeadDto>>> CreateLeadAsync(LeadDto dto)
        {
            try
            {
                var lead = await _leadService.CreateLeadAsync(dto);

                return StatusCode(lead.StatusCode, lead);

            }

            catch (Exception ex) { 
            
                return BadRequest(new CommonResponse<LeadDto>(false,ex.Message,400,null));
            }
        }

        [HttpGet]
        [Route("GetAllLeads")]
        [Authorize]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<CommonResponse<DashboardLeadDto>>> GetAllLeads()
        {
            try

            {
                var leads = await _leadService.GetAllLeadAsync();

                return StatusCode(leads.StatusCode, leads);
            }
            catch (Exception ex) {

                return BadRequest(new CommonResponse<DashboardLeadDto>(false, ex.Message, 400, null));
            }
        }


        [HttpGet]
        [Route("GetLeadById/{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]

        public async Task<ActionResult<CommonResponse<LeadDto>>> GetLeadById(int id)
        {
            try
            {
                var lead = await _leadService.GetLeadByIdAsync(id);
                return StatusCode(lead.StatusCode, lead);
            }
            catch(Exception ex)
            {
                return BadRequest(new CommonResponse<LeadDto>(false,ex.Message,400,null));
            }
        }



        [HttpGet]
        [Route("GetLeadByName/{name:alpha}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]

        public async Task<ActionResult<CommonResponse<LeadDto>>> GetLeadByName(string name)
        {
            try
            {
                var lead = await _leadService.GetLeadByNameAsync(name);
                return StatusCode(lead.StatusCode, lead);
            }
            catch (Exception ex)
            {
                return BadRequest(new CommonResponse<LeadDto>(false, ex.Message, 400, null));
            }
        }

        //[HttpDelete]
        //[Route("DeleteLead/{id:int}")]
        //[ProducesResponseType(200)]
        //[ProducesResponseType(400)]
        //[ProducesResponseType(401)]
        //[ProducesResponseType(404)]
        //[ProducesResponseType(500)]

        //public async Task<ActionResult<CommonResponse<object>>> DeleteLeadById(int id)
        //{
        //    try
        //    {
        //        var lead = _leadService.GetLeadByIdAsync(id);


        //    }
        //    catch (Exception ex)
        //    {

        //        return BadRequest(new CommonResponse<object>(false, ex.Message, 400, null));

        //    }
        //}
        [HttpPut]
        [Route("UpdateLead/{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<CommonResponse<LeadDto>>> UpdateLeadById(int id)
        {
            try
            {
                var lead = 
            }
        }
       


    }
}
