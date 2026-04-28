using Microsoft.AspNetCore.Mvc;

namespace Sem2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {

        [HttpPost]
        public async Task<IActionResult> Register()
                    {
            return Ok("Register API");
        }
    }
}
