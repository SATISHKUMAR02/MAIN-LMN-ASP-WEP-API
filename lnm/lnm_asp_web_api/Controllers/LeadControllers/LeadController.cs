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
    //[Authorize]
    public class LeadController : ControllerBase
    {
        private readonly ILeadService _leadService;
        public LeadController(ILeadService leadService)
        {
            _leadService = leadService;            
        }

        [HttpPost]
        [Route("CreateLeads")]
        [Authorize(Roles = "1,3")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<CommonResponse<LeadDto>>> CreateLead([FromBody] LeadDto dto, int id)
        {
            try
            {
                var lead = await _leadService.CreateLeadAsync(dto,id);

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
        [Route("GetAllLeadsByUsers")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<CommonResponse<DashboardLeadDto>>> GetAllLeadsByUsers(int id)
        {
            try

            {
                var leads = await _leadService.GetLeadByUserIdAsync(id);

                return StatusCode(leads.StatusCode, leads);
            }
            catch (Exception ex)
            {

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

        [HttpDelete] //================================================================================ for admin  -> direct deletion of lead
        [Route("DeleteLeadByAdmin/{id:int}")]
        [Authorize(Roles = "3")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]

        public async Task<ActionResult<CommonResponse<object>>> DeleteLeadAdminById(int id)
        {
            try
            {
                if (id < 0)
                {
                    return BadRequest(new CommonResponse<object>(false,"invalid input",400,null));
                }
                var lead = await _leadService.GetLeadByIdAsync(id);
                
               
                var result = await _leadService.DeleteLeadAdminAsync(id);
                return StatusCode(lead.StatusCode, id);

            }
            catch (Exception ex)
            {

                return BadRequest(new CommonResponse<object>(false, ex.Message, 400, null));

            }
        }

        [HttpDelete] //======================================================================================for Others -> delete flag is set to true
        [Route("DeleteTempLeadById/{id:int}")]
        [Authorize(Roles = "3")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]

        public async Task<ActionResult<CommonResponse<object>>> DeleteTempLeadById(int id,int userId)
        {
            try
            {
                if (id < 0)
                {
                    return BadRequest(new CommonResponse<object>(false, "invalid input", 400, null));
                }
                var lead = await _leadService.GetLeadByIdAsync(id);


                var result = await _leadService.DeleteLeadTempByIdAsync(id,userId);
                return StatusCode(lead.StatusCode, id);

            }
            catch (Exception ex)
            {

                return BadRequest(new CommonResponse<object>(false, ex.Message, 400, null));

            }
        }

        [HttpPut]
        [Route("UpdateLead/{id:int}")]
        [Authorize(Roles = "1,3")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<CommonResponse<LeadDto>>> UpdateLead(int id,[FromBody] LeadDto dto,int userId)
        {
            try
            {
                if (dto == null || dto.institution_id !=id)
                {
                    return BadRequest(new CommonResponse<LeadDto>(false, "invalid input credentials", 400, null));
                }
                var existingLead = await _leadService.UpdateLeadAsync(dto,userId);
                
                return StatusCode(existingLead.StatusCode, existingLead);

            }
            catch (Exception ex) {
                
                return BadRequest(new CommonResponse<LeadDto>(false, ex.Message, 400, null));

            }
        }

       




    }
}
