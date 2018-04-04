﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Trickery.WebApi.Controllers.Base;

namespace Trickery.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerAuthBase
    {
        public TestController(IUserIdProvider userIdProvider) 
            : base(userIdProvider)
        {
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

        [HttpGet]
        [Route("private")]
        [Authorize]
        public IActionResult Private()
        {
            return new JsonResult(new
            {
                Message = "Private endpoint " + GetUserId()
            });
        }

        [HttpGet]
        [Route("private/player")]
        [Authorize]
        //[Authorize(AuthConfig.Policy.IsPlayer)]
        public IActionResult PrivatePlayer()
        {
            return new JsonResult(new
            {
                Message = "Private player endpoint"
            });
        }

        [HttpGet]
        [Route("private/admin")]
        [Authorize]
        //[Authorize(AuthConfig.Policy.IsAdmin)]
        public IActionResult PrivateAdmin()
        {
            return new JsonResult(new
            {
                Message = "Private admin endpoint"
            });
        }
    }
}
