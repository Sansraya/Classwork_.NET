using System.ComponentModel.DataAnnotations.Schema;

namespace Sem2.Data.Entities
{
    public class Module
    {
        public int Id { get; set; } 
        public string Title { get; set; } = string.Empty;
        public int Credit { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; } = null!;
    }
}
