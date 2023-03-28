using System.ComponentModel.DataAnnotations;

namespace mefit_backend.models.domain
{
    public class User
    {
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; }
        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }
        [MaxLength(320)]
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public bool IsContributor { get; set; }
        [Required]
        public bool IsAdmin { get; set; }

        // relationship 
        //public Profile Profile { get; set; }
    }
}
