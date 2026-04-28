namespace Sem2.Modals.DTO
{
    public class RegistrationResponse
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public List<string> Errors { get; set; }
    }
}
