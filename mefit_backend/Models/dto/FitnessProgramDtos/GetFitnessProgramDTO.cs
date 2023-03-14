using mefit_backend.models.domain;

namespace mefit_backend.Models.dto.FitnessProgramDtos
{
    public class GetFitnessProgramDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }

        // Relationship
        public List<string> Workouts { get; set; }
        public List<string> FitnessProgramGoals { get; set; }
    }
}
