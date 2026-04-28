using Microsoft.AspNetCore.Mvc;
using Sem2.Modals.DTO.RequestDTO;
using Sem2.Services.Interface;
using System.Threading.Tasks;

namespace Sem2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : Controller
    {

        [HttpPost]
        public async Task<IActionResult> RegisterUser(RegisterDTO registerDTO)
        {
            var registrationResponse = await authService.RegisterUser(registerDTO);

            if (registrationResponse.Success)
            {
                return Ok(registrationResponse);
            }

            return BadRequest(registrationResponse);
        }
    }
}
