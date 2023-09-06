using System.ComponentModel.DataAnnotations;

namespace NikoraApi.Dtos
{
    public class LoginRequestDto
    {
        [Required, DataType(DataType.Text)]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Username must be between 5 and 50 characters")]
        public string UserName { get; set; } = string.Empty;

        [Required, DataType(DataType.Password)]
        [StringLength(256, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 50 characters")]
        public string Password { get; set; } = string.Empty;
    }
}
