using System.ComponentModel.DataAnnotations;

namespace mefit_backend.models.domain
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public bool IsContributor { get; set; }
        [Required]
        public bool IsAdmin { get; set;}

        // relationship 
        public Profile Profile { get; set; }
    }
}
