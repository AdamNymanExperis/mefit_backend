using System.ComponentModel.DataAnnotations;

namespace mefit_backend.models.domain
{
    public class Address
    {
        public string Id { get; set; }
        [Required]
        public string Adress_line { get; set; }
        [Required]
        public int Postal_code { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        
        // relationship 
        public Profile Profile { get; set; }
    }
}
