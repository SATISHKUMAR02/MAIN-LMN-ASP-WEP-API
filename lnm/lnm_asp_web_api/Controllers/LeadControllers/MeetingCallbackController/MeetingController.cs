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

        public async Task<ActionResult<CommonResponse<StatusUpdatedto>>> CreateNewStatusUpdate([FromBody] StatusUpdatedto dto, int userid,int institutitonId)
        {
            try
            {
                if (dto == null)
                {
                    return BadRequest(new CommonResponse<StatusUpdatedto>(false, "invalid input credentials", 404, null));
                }
                var status = await _services.CreateStatusUpdateAsync(dto,userid,institutitonId);

                return StatusCode(status.StatusCode, status);
            }
            catch (Exception ex)
            {

                return BadRequest(new CommonResponse<StatusUpdatedto>(false, ex.Message, 404, null));
            }
        }


        [HttpGet]
        [Route("GetAllInstitutionMeetingsandCallaback")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<CommonResponse<List<MeetingCallbackdashdto>>>> GetMeetingandCallbackByInstitution(int institutionid)
        {
            try
            {
                if (institutionid < 0)
                {
                    return BadRequest(new CommonResponse<List<MeetingCallbackdashdto>>(false, "invalid credentials", 400, null)); ;
                }
                var meetings = await _services.GetMeetingsByInstitutionId(institutionid);
                return StatusCode(meetings.StatusCode, meetings);
            }

           
            catch (Exception ex)
            {
                return BadRequest(new CommonResponse<List<MeetingCallbackdashdto>>(false, ex.Message, 404, null));
            }
        }

        [HttpPost]
        [Route("ScheduleNewMeeting")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<CommonResponse<ScheduleMeetingdto>>> ScheduleNewMeeting([FromBody] ScheduleMeetingdto dto,int userid,int institutionid)
        {
            try
            {
                if (dto == null)
                {
                    return BadRequest(new CommonResponse<ScheduleMeetingdto>(false, "invalid credentials", 404, null));
                }
                var existingMeeting = await _services.CreateMeetingAsync(dto,userid,institutionid);

                return StatusCode(existingMeeting.StatusCode, existingMeeting);
            }
            catch (Exception ex)
            {

                return BadRequest(new CommonResponse<ScheduleMeetingdto>(false, ex.Message, 404, null));
            }
        }

        [HttpPut]
        [Route("UpdateScheduledMeeting")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<CommonResponse<UpdateMeetingdto>>> UpdateScheduleMeeting(int institutionid, [FromBody] UpdateMeetingdto dto,int userid, int meetingid)
        {
            try
            {
                if (institutionid < 0)
                {
                    return NotFound(new CommonResponse<UpdateMeetingdto>(false, "invalid Credentials", 404, null));
                }
                var existingMeeting = await _services.UpdateMeetingAsync(dto,userid,institutionid,meetingid);
                return StatusCode(existingMeeting.StatusCode, existingMeeting);
            }
            catch (Exception ex)
            {
                return NotFound(new CommonResponse<UpdateMeetingdto>(false, ex.Message, 404, null));

            }

        }

        [HttpGet]
        [Route("GetAllScheduledMeetingsAndCallback")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]

        public async Task<ActionResult<CommonResponse<List<MeetingCallbackdashdto>>>> GetAllMeetingCallback(int userid)
        {
            try
            {
                var events = await _services.GetAllMeetingCallbackAsync(userid);
                return StatusCode(events.StatusCode, events);

            }
            catch (Exception ex)
            {
                return BadRequest(new CommonResponse<List<MeetingCallbackdashdto>>(false, ex.Message, 404, null));

            }

        }

        [HttpDelete]
        [Route("DeleteTempmeeting")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]

        public async Task<ActionResult<CommonResponse<object>>> DeleteTempMeeting(int institutionid,int meetingid, int userid)
        {
            try
            {
                if (institutionid < 0 && meetingid<0)
                {
                    return BadRequest(new CommonResponse<object>(false, "invalild input credentials", 404, null));
                }
                var meeting = await _services.DeleteTempMeetingAsync(meetingid,institutionid,userid);
                return StatusCode(meeting.StatusCode, meeting);
            }
            catch (Exception ex)
            {
                return BadRequest(new CommonResponse<object>(false, ex.Message, 404, null));

            }

        }

        [HttpDelete]
        [Route("Deletemeeting")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]

        public async Task<ActionResult<CommonResponse<object>>> DeleteMeeting(int institutionid, int meetingid)
        {
            try
            {
                if (institutionid < 0 && meetingid < 0)
                {
                    return BadRequest(new CommonResponse<object>(false, "invalild credentials", 404, null));
                }
                var meeting = await _services.DeleteMeetingAsync(institutionid, meetingid);
                return StatusCode(meeting.StatusCode, meeting);
            }
            catch (Exception ex)
            {
                return BadRequest(new CommonResponse<object>(false, ex.Message, 404, null));

            }

        }
    }
}