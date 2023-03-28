using System.ComponentModel.DataAnnotations;

namespace mefit_backend.models.domain
{
    public class Address
    {
        public int Id { get; set; }
        [Required]
        public string AdressLine { get; set; }
        [Required]
        public int PostalCode { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        
        // relationship 
        //public Profile Profile { get; set; }
    }
}
