using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Trickery.DAL.Repository.Document;
using Trickery.WebApi.Controllers.Base;

namespace Trickery.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerAuthBase
    {
        private readonly ITestMessageRepository testMessageRepository;

        public TestController(IUserIdProvider userIdProvider,
            ITestMessageRepository testMessageRepository) 
            : base(userIdProvider)
        {
            this.testMessageRepository = testMessageRepository;
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
        
        [HttpPost]
        [Route("messages")]
        [Authorize]
        //[Authorize(AuthConfig.Policy.IsAdmin)]
        public async Task<IActionResult> AddMessage(string message)
        {
            var createdMessage = await testMessageRepository.Add(new Model.Document.TestMessage
            {
                Id = Guid.NewGuid(),
                Message = message,
                UserId = GetUserId()
            });
            return new JsonResult(new
            {
                Message = createdMessage
            });
        }

        [HttpGet]
        [Route("messages")]
        [Authorize]
        //[Authorize(AuthConfig.Policy.IsAdmin)]
        public async Task<IActionResult> GetMessages()
        {
            var messages = await testMessageRepository.GetAll();

            return new JsonResult(new
            {
                Messages = messages
            });
        }
    }
}
