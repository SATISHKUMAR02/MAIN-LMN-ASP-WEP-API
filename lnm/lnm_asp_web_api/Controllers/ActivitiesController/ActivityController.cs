using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using model;
using model.Activities;
using model.Institution;
using services.Application_Services.ActivityServices;
using services.Application_Services.ActivityServices.DTO;
using services.Application_Services.LeadServices.DTO;

namespace lnm_asp_web_api.Controllers.ActivitiesController
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityService _activityService;
        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }
        [HttpGet]
        [Route("GetAllActivities")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<CommonResponse<TblActivityMaster>>> GetAllActivities()
        {
            try

            {
                var activities = await _activityService.GetAllActivityAsync();

                return StatusCode(activities.StatusCode, activities);
            }
            catch (Exception ex)
            {

                return BadRequest(new CommonResponse<TblActivityMaster>(false, ex.Message, 400, null));
            }
        }

        [HttpGet]
        [Route("GetAllInstitutionActivities")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<CommonResponse<AddInstitutionActivitydto>>> GetAllInstitutionActivities(int institutionId)
        {
            try

            {
                var activities = await _activityService.GetAllInstitutionActivityAsync(institutionId);

                return StatusCode(activities.StatusCode, activities);
            }
            catch (Exception ex)
            {

                return BadRequest(new CommonResponse<TblActivityMaster>(false, ex.Message, 400, null));
            }
        }

        [HttpPost]
        [Route("CreateNewSchoolActivity")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<CommonResponse<TblInstitutionActivity>>> CreateNewSchoolActivity([FromBody] AddInstitutionActivitydto dto,int userid,int institutionid , int activityid)
        {
            try
            {
                var activity = await _activityService.CreateNewActivityAsync(dto,userid,institutionid,activityid);
                return StatusCode(activity.StatusCode, activity);
            }
            catch (Exception ex) {
                return BadRequest(new CommonResponse<AddInstitutionActivitydto>(false,ex.Message,400,null));
            
            }
        }

        [HttpPut]
        [Route("updateSchoolActivity")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<CommonResponse<TblInstitutionActivity>>> UpdateSchoolActivity(int activityid,int institutionid ,int userid ,[FromBody] AddInstitutionActivitydto dto)
        {
            try
            {
                var activity = await _activityService.UpdateActivityAsync(userid,institutionid,activityid,dto);

                return StatusCode(activity.StatusCode, activity);
            }
            catch (Exception ex)
            {
                return BadRequest(new CommonResponse<AddInstitutionActivitydto>(false, ex.Message, 400, null));

            }
        }

        [HttpDelete]
        [Route("DeleteSchoolActivity/{id:int}")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<CommonResponse<TblInstitutionActivity>>> DeleteSchoolActivity(int id)
        {
            try
            {
                var activity = await _activityService.DeleteActivityAsync(id);

                return StatusCode(activity.StatusCode, activity);
            }
            catch (Exception ex)
            {
                return BadRequest(new CommonResponse<AddInstitutionActivitydto>(false, ex.Message, 400, null));

            }
        }


    }
}
