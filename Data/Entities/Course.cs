using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;

namespace Sem2.Data.Entities
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;
        public int DurationYears { get; set; } 
        public List<Module>? Modules { get;     set; }
    }
}
