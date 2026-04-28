using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Sem2.Data.Entities
{
    public class User:IdentityUser<Guid>
    {
        [Required(ErrorMessage ="First name is required!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required!")]
        public string LastName { get; set; }
        [Required, Range(18, 100, ErrorMessage = "Age must be between 18 and 100!")]
        public int Age{ get; set; }
    }
}
