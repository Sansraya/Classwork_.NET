namespace Sem2.Modals.DTO.RequestDTO
{
    public class ModuleDTO
    {
        public required string Title { get; set; }
        public required int ModuleCredits { get; set; }
        public int CourseId { get; set; }
        

    }
}
