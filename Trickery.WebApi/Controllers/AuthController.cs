using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trickery.Auth;
using Trickery.WebApi.Config.Auth;
using Trickery.WebApi.Controllers.Base;

namespace Trickery.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerAuthBase
    {
        private readonly IUserRegistrationDataProvider registrationDataProvider;
        private readonly IUserRegistrator userRegistrator;

        public AuthController(
            IUserContextDataProvider userContextDataProvider,
            IUserRegistrationDataProvider registrationDataProvider,
            IUserRegistrator userRegistrator) 
            : base(userContextDataProvider)
        {
            this.registrationDataProvider = registrationDataProvider;
            this.userRegistrator = userRegistrator;
        }

        [HttpGet]
        [Authorize]
        [Route("tryregister")]
        public async Task<IActionResult> TryRegister()
        {
            var registrationData = registrationDataProvider.GetUserData(HttpContext);

            var user = await userRegistrator.TryRegisterUser(registrationData);

            return new JsonResult(user);
        }

        [HttpGet]
        [Authorize]
        [Route("user")]
        public async Task<IActionResult> GetUser()
        {
            var userData = await GetUserDataAsync();

            return new JsonResult(userData);
        }
    }
}