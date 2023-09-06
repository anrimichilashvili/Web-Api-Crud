namespace NikoraApi.Dtos
{
    public class LoginResponseDto
    {
        public bool Success { get; set; }
        public string AccessToken { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public int UserId { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
