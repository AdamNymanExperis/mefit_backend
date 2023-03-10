using System.ComponentModel.DataAnnotations;

namespace mefit_backend.Models.DTO.User
{
    public class PasswordDTO
    {
        [Required]
        public string Password { get; set; }
    }
}
