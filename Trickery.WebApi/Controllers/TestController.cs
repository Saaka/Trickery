using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Trickery.Auth;
using Trickery.DAL.Repository.Document;
using Trickery.WebApi.Controllers.Base;

namespace Trickery.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerAuthBase
    {
        private readonly ITestMessageRepository testMessageRepository;
        
        public TestController(
            IExternalUserIdProvider userIdProvider, 
            IUserDataProvider userDataProvider,
            ITestMessageRepository testMessageRepository) 
            : base(userIdProvider, userDataProvider)
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
                Message = "Private endpoint " + GetExternalUserId()
            });
        }

        [HttpPost]
        [Route("messages")]
        [Authorize]
        public async Task<IActionResult> AddMessage(string message)
        {
            var createdMessage = await testMessageRepository.Add(new Model.Document.TestMessage
            {
                Id = Guid.NewGuid(),
                Message = message,
                UserId = GetExternalUserId()
            });
            return new JsonResult(new
            {
                Message = createdMessage
            });
        }

        [HttpPost]
        [Route("messages/a")]
        [Authorize]
        public async Task<IActionResult> AddMessageA(string message)
        {
            var createdMessage = await testMessageRepository.Add(new Model.Document.TestMessageA
            {
                Id = Guid.NewGuid(),
                MessageA = message,
                UserId = GetExternalUserId()
            });
            return new JsonResult(new
            {
                Message = createdMessage
            });
        }

        [HttpPost]
        [Route("messages/b")]
        [Authorize]
        public async Task<IActionResult> AddMessageB(string message)
        {
            var createdMessage = await testMessageRepository.Add(new Model.Document.TestMessageB
            {
                Id = Guid.NewGuid(),
                MessageB = message,
                UserId = GetExternalUserId()
            });
            return new JsonResult(new
            {
                Message = createdMessage
            });
        }

        [HttpGet]
        [Route("messages")]
        [Authorize]
        public async Task<IActionResult> GetMessages()
        {
            var messages = await testMessageRepository.GetAll();

            return new JsonResult(new
            {
                Messages = messages
            });
        }

        [HttpGet]
        [Route("messages/a")]
        [Authorize]
        public async Task<IActionResult> GetMessagesA()
        {
            var messages = await testMessageRepository.GetAllMessagesA();

            return new JsonResult(new
            {
                Messages = messages
            });
        }

        [HttpGet]
        [Route("messages/b")]
        [Authorize]
        public async Task<IActionResult> GetMessagesB()
        {
            var messages = await testMessageRepository.GetAllMessagesB();

            return new JsonResult(new
            {
                Messages = messages
            });
        }

        [HttpDelete]
        [Route("messages")]
        [Authorize]
        public async Task<IActionResult> DeleteMessages()
        {
            await testMessageRepository.ClearCollection();

            return new OkResult();
        }
    }
}
