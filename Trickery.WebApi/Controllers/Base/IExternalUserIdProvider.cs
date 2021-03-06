﻿using Microsoft.AspNetCore.Http;

namespace Trickery.WebApi.Controllers.Base
{
    public interface IExternalUserIdProvider
    {
        string GetUserId(HttpContext context);
    }
}
