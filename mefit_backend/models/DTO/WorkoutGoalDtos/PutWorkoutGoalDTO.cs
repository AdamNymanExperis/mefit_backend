namespace mefit_backend.models.DTO.WorkoutGoalDtos
{
    public class PutWorkoutGoalDTO
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // relationship
        public int WorkoutId { get; set; }
        public int GoalId { get; set; }
    }
}
