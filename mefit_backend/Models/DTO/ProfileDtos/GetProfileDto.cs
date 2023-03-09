using mefit_backend.models.domain;

namespace mefit_backend.Models.DTO.ProfileDtos
{
    public class GetProfileDto
    {
        public int Id { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }

        // relationships
        public int UserId { get; set; }
        public int AddressId { get; set; }
        public List<string> Goals { get; set; }
        public List<string> Impairments { get; set; }
    }
}
