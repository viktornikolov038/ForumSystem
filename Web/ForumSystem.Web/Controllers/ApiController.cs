using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ForumSystem.Web.Controllers
{
    [Authorize]
    [ApiController]
    public abstract class ApiController : ControllerBase
    {
    }
}
