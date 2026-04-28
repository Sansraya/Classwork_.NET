using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sem2.Data;
using Sem2.Data.Entities;
using Sem2.Modals.DTO.RequestDTO;
using Sem2.Services.Implementation;
using Sem2.Services.Interface;

namespace Sem2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

       
    public class ModuleController : ControllerBase
    {
        private readonly IModuleService moduleService;
        private static readonly ApplicationDbContext dbContext;
        public ModuleController(IModuleService moduleService)
        {
            this.moduleService = moduleService;
        }

        [HttpPost]
        public async Task<IActionResult> AddModule(ModuleDTO moduleDTO)
        {
            var result = await moduleService.AddModuleAsync(moduleDTO);
            return Ok(result);
        }
    }
}
