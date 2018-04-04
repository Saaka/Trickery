using Microsoft.AspNetCore.Http;

namespace Trickery.WebApi.Controllers.Base
{
    public interface IUserIdProvider
    {
        string GetUserId(HttpContext context);
    }
}
