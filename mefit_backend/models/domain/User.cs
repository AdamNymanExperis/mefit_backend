using System.ComponentModel.DataAnnotations;

namespace mefit_backend.models.domain
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string First_name { get; set; }
        [Required]
        public string Last_name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public bool Is_Contributor { get; set; }
        [Required]
        public bool Is_Admin { get; set;}

        // relationship 
        public Profile Profile { get; set; }
    }
}
