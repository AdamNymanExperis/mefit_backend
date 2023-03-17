using mefit_backend.models.domain;

namespace mefit_backend.models.DTO.FitnessProgramGoalDtos
{
    public class GetFitnessProgramGoalDTO
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // relationships
        public string Goal { get; set; }
        public string FitnessProgram { get; set; }
    }
}
