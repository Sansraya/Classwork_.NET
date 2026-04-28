using Sem2.Modals.DTO.RequestDTO;

namespace Sem2.Services.Interface
{
    public interface IAuthService
    {
        public Task<string> RegisterUser(RegisterDTO registerDTO);
    }
}
