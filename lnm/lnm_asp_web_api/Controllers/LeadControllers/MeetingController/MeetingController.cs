using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using model;
using services.Application_Services.LeadServices.Meetings;
using services.Application_Services.LeadServices.Meetings.DTO;

namespace lnm_asp_web_api.Controllers.LeadControllers.MeetingController
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class MeetingController : ControllerBase
    {
        private readonly IScheduleMeetingCallback _services;
        public MeetingController(IScheduleMeetingCallback services)
        {
            _services = services;
        }
        [HttpPost]
        [Route("CreateNewStatusUpdate")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]

        public async Task<ActionResult<CommonResponse<StatusUpdatedto>>> CreateNewStatusUpdate(StatusUpdatedto dto)
        {
            try
            {
                if (dto == null)
                {
                    return BadRequest(new CommonResponse<StatusUpdatedto>(false, "invalid input credentials", 404, null));
                }
                var status = await _services.CreateStatusUpdateAsync(dto);

                return StatusCode(status.StatusCode, status);
            }
            catch (Exception ex)
            {

                return BadRequest(new CommonResponse<StatusUpdatedto>(false, ex.Message, 404, null));
            }
        }


        [HttpPost]
        [Route("ScheduleNewMeeting")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<CommonResponse<ScheduleMeetingdto>>> ScheduleNewMeeting([FromBody] ScheduleMeetingdto dto)
        {
            try
            {
                if (dto == null)
                {
                    return BadRequest(new CommonResponse<ScheduleMeetingdto>(false, "invalid credentials", 404, null));
                }
                var existingMeeting = await _services.CreateMeetingAsync(dto);

                return StatusCode(existingMeeting.StatusCode, existingMeeting);
            }
            catch (Exception ex)
            {

                return BadRequest(new CommonResponse<ScheduleMeetingdto>(false, ex.Message, 404, null));
            }
        }

        [HttpPut]
        [Route("UpdateScheduledMeeting/{id:int}")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<CommonResponse<ScheduleMeetingdto>>> UpdateScheduleMeeting(int id, [FromBody] ScheduleMeetingdto dto)
        {
            try
            {
                if (id < 0 || dto.institution_id == id)
                {
                    return NotFound(new CommonResponse<ScheduleMeetingdto>(false, "invalid Credentials", 404, null));
                }
                var existingMeeting = await _services.UpdateMeetingAsync(dto);
                return StatusCode(existingMeeting.StatusCode, existingMeeting);
            }
            catch (Exception ex)
            {
                return NotFound(new CommonResponse<ScheduleMeetingdto>(false, ex.Message, 404, null));

            }

        }

        [HttpGet]
        [Route("GetAllScheduledMeetingsAndCallback")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]

        public async Task<ActionResult<CommonResponse<List<MeetingCallbackdashdto>>>> GetAllMeetingCallback()
        {
            try
            {
                var events = await _services.GetAllMeetingCallbackAsync();
                return StatusCode(events.StatusCode, events);

            }
            catch (Exception ex)
            {
                return BadRequest(new CommonResponse<List<MeetingCallbackdashdto>>(false, ex.Message, 404, null));

            }

        }
    }
}