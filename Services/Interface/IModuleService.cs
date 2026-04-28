using Sem2.Modals.DTO.RequestDTO;

namespace Sem2.Services.Interface
{
    public interface IModuleService
    {
        public Task<string> AddModuleAsync (ModuleDTO moduleDTOs);
    }
}
