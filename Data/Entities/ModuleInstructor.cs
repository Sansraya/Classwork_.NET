namespace Sem2.Data.Entities
{
    public class ModuleInstructor
    {
        public int Id { get; set; }
        public int ModuleId { get; set; }
        public Module Module { get; set; } = null!;
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; } = null!;
    }
}
