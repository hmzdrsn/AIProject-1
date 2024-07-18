using AIProject.Application.Features.Chat.Queries.GetChats;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AIProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExceptionTestController : ControllerBase
    {

        List<string> data = new List<string>()
        {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
        };
        [HttpGet]
        public async Task<IActionResult> GetChats()
        {
            var x = data.Find(x=>x=="S");
            return Ok(x);
        }
    }
}
