using System.ComponentModel.DataAnnotations;

namespace Sem2.Modals.DTO.ResponseDTO
{
    public class LoginDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
