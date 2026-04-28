using Sem2.Modals.DTO;
using Sem2.Modals.DTO.RequestDTO;
using Sem2.Modals.DTO.ResponseDTO;

namespace Sem2.Services.Interface
{
    public interface IAuthService
    {
        public Task<RegistrationResponse> RegisterUser(RegisterDTO registerDTO);
        public Task<LoginResponse> Login(LoginDTO loginDTO);

    }
}
