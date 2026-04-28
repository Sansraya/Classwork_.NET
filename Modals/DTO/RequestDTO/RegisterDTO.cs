using System.ComponentModel.DataAnnotations;

namespace Sem2.Modals.DTO.RequestDTO
{
    public class RegisterDTO
    {
        [Required,StringLength(50,ErrorMessage ="First Name must be 50")]
        public string FirstName { get; set; }
        [Required, StringLength(50, ErrorMessage = "Last Name must be 50")]
        public string LastName { get; set; }
        [Required(ErrorMessage ="Phone number is required"), StringLength(50)]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Email is required"), StringLength(50)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required"), StringLength(50)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Age is required"), StringLength(50)]
        public int Age { get;set; }
    }
}
