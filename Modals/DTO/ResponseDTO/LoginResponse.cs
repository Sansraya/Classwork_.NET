namespace Sem2.Modals.DTO.ResponseDTO
{
    public class LoginResponse
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public string? Token { get; set; }
    }
}
