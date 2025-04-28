using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using model;
using services.Application_Services.LeadServices.Meetings;
using services.Application_Services.LeadServices.Meetings.DTO;

namespace lnm_asp_web_api.Controllers.LeadControllers.MeetingCallbackController
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CallbackController : ControllerBase
    {
        private readonly IScheduleMeetingCallback _services;
        public CallbackController(IScheduleMeetingCallback services)
        {
            _services = services;
        }
        [HttpPost]
        [Route("CreateNewCallback")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<CommonResponse<ScheduleCallbackdto>>> CreateNewCallback([FromBody] ScheduleCallbackdto dto)
        {
            try
            {
                if (dto == null)
                {

                    return BadRequest(new CommonResponse<ScheduleCallbackdto>(false, "invalid inputs", 404, null));

                }
                var callback = await _services.CreateCallbackAsync(dto);

                return StatusCode(callback.StatusCode, callback);
            }
            catch (Exception ex)
            {

                return BadRequest(new CommonResponse<ScheduleCallbackdto>(false, ex.Message, 404, null));
            }
        }
        [HttpPut]
        [Route("UpdateCallback/{id:int}")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<CommonResponse<ScheduleCallbackdto>>> CreateNewCallback(int id,[FromBody] ScheduleCallbackdto dto)
        {
            try
            {
                if (dto == null || dto.meeting_id==id)
                {

                    return BadRequest(new CommonResponse<ScheduleCallbackdto>(false, "invalid inputs", 404, null));

                }
                var callback = await _services.UpdateCallbackAsync(dto);

                return StatusCode(callback.StatusCode, callback);
            }
            catch (Exception ex)
            {

                return BadRequest(new CommonResponse<ScheduleCallbackdto>(false, ex.Message, 404, null));
            }
        }
    }
    
    
   
}
