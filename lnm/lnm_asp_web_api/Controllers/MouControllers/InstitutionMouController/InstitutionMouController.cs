using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using model;
using services.Application_Services.MouServices.DTO;
using services.Application_Services.MouServices.TelecallerServices;

namespace lnm_asp_web_api.Controllers.MouControllers.InstitutionMouController
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class InstitutionMouController : ControllerBase
    {
        private readonly IInstitutionService _institutionService;
        public InstitutionMouController(IInstitutionService institutionService)
        {
            _institutionService = institutionService;
        }
        [HttpGet]
        [Route("GetAllInstitutionMou")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]

        public async Task<ActionResult<CommonResponse<Institutiondto>>> GetAllInstitutionMou()
        {
            try
            {
                var institution = await _institutionService.GetAllInstitutitionMouAsync();
                return StatusCode(institution.StatusCode, institution);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetInstitutionByVersion/{version:float}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]

        public async Task<ActionResult<CommonResponse<object>>> GetConnectorMouByVersion(float version)
        {
            try
            {
                if (version < 0)
                {
                    return BadRequest(new CommonResponse<object>(false, "invalid credentials", 404, null));
                }
                var mou = await _institutionService.GetInstitutionMouByVersion(version);
                return StatusCode(mou.StatusCode, mou);
            }
            catch (Exception ex)
            {
                return BadRequest(new CommonResponse<object>(false, ex.Message, 404, null));
            }
        }

        [HttpGet]
        [Route("GetLatestInstitutionMouByVersion")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]

        public async Task<ActionResult<CommonResponse<object>>> GetLatestConnectorMouByVersion()
        {
            try
            {
                var mou = await _institutionService.GetCurrentInstitutionMouByVersionAsync();
                return StatusCode(mou.StatusCode, mou);
            }
            catch (Exception ex)
            {
                return BadRequest(new CommonResponse<object>(false, ex.Message, 404, null));
            }
        }

    }
}
