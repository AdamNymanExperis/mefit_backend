using mefit_backend.models.domain;

namespace mefit_backend.models.DTO.FitnessProgramGoalDtos
{
    public class PutFitnessProgramGoalDTO
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // relationships
        public int GoalId { get; set; }
        public int FitnessProgramId { get; set; }
    }
}
