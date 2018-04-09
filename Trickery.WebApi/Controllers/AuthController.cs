using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trickery.Auth;
using Trickery.WebApi.Config.Auth;

namespace Trickery.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IUserRegistrationDataProvider userDataProvider;
        private readonly IUserRegistrator userRegistrator;

        public AuthController(IUserRegistrationDataProvider userDataProvider,
            IUserRegistrator userRegistrator)
        {
            this.userDataProvider = userDataProvider;
            this.userRegistrator = userRegistrator;
        }
        [HttpGet]
        [Authorize]
        [Route("tryregister")]
        public async Task<IActionResult> TryRegister()
        {
            var registrationData = userDataProvider.GetUserData(HttpContext);

            var user = await userRegistrator.TryRegisterUser(registrationData);

            return new JsonResult(user);
        }
    }
}