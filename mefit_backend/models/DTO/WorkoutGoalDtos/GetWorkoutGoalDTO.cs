using mefit_backend.models.domain;

namespace mefit_backend.models.DTO.WorkoutGoalDtos
{
    public class GetWorkoutGoalDTO
    {
        public int Id { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }

        // relationship
        public string Workout { get; set; }
        public string Goal { get; set; }
    }
}
