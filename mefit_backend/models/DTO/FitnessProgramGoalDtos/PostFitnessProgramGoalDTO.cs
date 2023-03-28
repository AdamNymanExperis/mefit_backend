using mefit_backend.models.domain;

namespace mefit_backend.models.DTO.FitnessProgramGoalDtos
{
    public class PostFitnessProgramGoalDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // relationships
        public int GoalId { get; set; }
        public int FitnessProgramId { get; set; }
    }
}
