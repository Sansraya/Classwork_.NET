using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Sem2.Data;
using Sem2.Data.Entities;
using Sem2.Modals.DTO;
using Sem2.Modals.DTO.RequestDTO;
using Sem2.Services.Interface;

namespace Sem2.Services.Implementation
{
    public class AuthService:IAuthService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<User> userManager;
        public AuthService(ApplicationDbContext dbContext,UserManager<User> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }
        public async Task<RegistrationResponse> RegisterUser(RegisterDTO registerDTO)
        {
            var transaction = await dbContext.Database.BeginTransactionAsync();

            var user = new User
            {
                FirstName = registerDTO.FirstName,
                LastName = registerDTO.LastName,
                Email = registerDTO.Email,
                Age=registerDTO.Age,
                PhoneNumber = registerDTO.Phone,
            };

            var result = await userManager.CreateAsync(user, registerDTO.Password);
            if (!result.Succeeded)
            {
                return new RegistrationResponse
                                    {
                    Success = false,
                    Message = "User Creation Failed",
                    Errors = result.Errors.Select(e => e.Description).ToList()
                };
           
            }
            
           var resultrole = await userManager.AddToRoleAsync(user, "Student");

            if (!resultrole.Succeeded)
            {
                await transaction.RollbackAsync();
                return new RegistrationResponse
                {
                    Success = false,
                    Message = "User Role Assignment Failed",
                    Errors = resultrole.Errors.Select(e => e.Description).ToList()
                };
            }

            await transaction.CommitAsync();
            return new RegistrationResponse
            {
                Success = true,
                Message = "User Registered Successfully!",
                Errors = new List<string>()
            };
        }
    }
}
