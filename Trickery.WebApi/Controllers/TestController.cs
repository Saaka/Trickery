using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Trickery.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        [Route("private")]
        [Authorize]
        public IActionResult Private()
        {
            return new JsonResult(new
            {
                Message = "Private endpoint"
            });
        }

        [HttpGet]
        [Route("public")]
        public IActionResult Public()
        {
            return new JsonResult(new
            {
                Message = "Public endpoint"
            });
        }
    }
}
