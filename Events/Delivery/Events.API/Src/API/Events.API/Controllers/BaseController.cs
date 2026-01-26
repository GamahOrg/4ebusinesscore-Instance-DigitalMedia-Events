using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;

namespace Events.API.Controller
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize]
    public class BaseController : ControllerBase
    {
       
    }
}
