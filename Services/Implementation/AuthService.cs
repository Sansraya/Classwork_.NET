using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sem2.Data;
using Sem2.Data.Entities;
using Sem2.Modals.DTO;
using Sem2.Modals.DTO.RequestDTO;
using Sem2.Modals.DTO.ResponseDTO;
using Sem2.Services.Interface;

namespace Sem2.Services.Implementation
{
    public class AuthService:IAuthService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        public AuthService(ApplicationDbContext dbContext,UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public async Task<RegistrationResponse> RegisterUser(RegisterDTO registerDTO)
        {

          
                var transaction = await dbContext.Database.BeginTransactionAsync();
            try
            {
                var user = new User
                {
                    FirstName = registerDTO.FirstName,
                    LastName = registerDTO.LastName,
                    Email = registerDTO.Email,
                    Age = registerDTO.Age,
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
            }catch(Exception ex)
            {
               await transaction.RollbackAsync();
                return new RegistrationResponse
                {
                    Success = false,
                    Message = "An error occurred during registration.",
                    Errors = new List<string> { ex.Message }
                };
            }
        }

        public async Task<LoginResponse> Login(LoginDTO loginDTO)
        {
            User? user = await userManager.FindByEmailAsync(loginDTO.Email);
            if (user == null)
            {
                return new LoginResponse
                {
                    Success = false,
                    Message = "User not found"
                };
            }

            var result = await userManager.CheckPasswordAsync(user, loginDTO.Password);
            if (!result)
            {
                return new LoginResponse
                {
                    Success = false,
                    Message = "Invalid password"
                };
            }

            var signInResult = await signInManager.CheckPasswordSignInAsync(user, loginDTO.Password, lockoutOnFailure: true);
            if (!signInResult.Succeeded)
            {
                return new LoginResponse
                {
                    Success = false,
                    Message = "Invalid password"
                };
            }

            return new LoginResponse
            {
                Success = true,
                Message = "Login successful",

            };
        }
    }
}
