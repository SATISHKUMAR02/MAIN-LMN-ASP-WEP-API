using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lnm_asp_web_api.Controllers.EmployeeController.SubConnector
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    
    public class SubConnectorController : ControllerBase
    {
    }
}
