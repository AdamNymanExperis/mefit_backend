using mefit_backend.models.domain;

namespace mefit_backend.models.DTO.WorkoutGoalDtos
{
    public class GetWorkoutGoalDTO
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // relationship
        public string Workout { get; set; }
        public string Goal { get; set; }
    }
}
