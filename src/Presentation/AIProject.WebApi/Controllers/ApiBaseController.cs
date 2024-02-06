using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using MediatR;

namespace AIProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class ApiBaseController : ControllerBase
    {
        
        public string AccessToken
        {
            get
            {
                if (HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues authHeaderValues))
                {
                    string accessToken = authHeaderValues.ToString();
                    return accessToken.StartsWith("Bearer ") ? accessToken.Substring("Bearer ".Length).Trim() : accessToken;
                }

                return "";
            }
        }
    }
}
