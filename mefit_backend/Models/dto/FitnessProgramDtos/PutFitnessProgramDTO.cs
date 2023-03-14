using mefit_backend.models.domain;

namespace mefit_backend.Models.dto.FitnessProgramDtos
{
    public class PutFitnessProgramDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }

    }
}
