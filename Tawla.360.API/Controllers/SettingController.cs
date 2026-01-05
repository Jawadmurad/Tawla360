using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Tawla._360.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SettingController : ControllerBase
    {
        [HttpGet("GetLanguages")]
        public async Task<IActionResult> GetLanguages()
        {
            return Ok(new List<Lang>()
            {
                new Lang()
                {
                    Code="ar",
                    Name="العربية",
                },
                new Lang()
                {
                    Code="en",
                    Name="الإنجليزية",
                }
            });
        }
    }
    public record Lang
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
