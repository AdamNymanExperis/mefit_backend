namespace mefit_backend.models.domain
{
    public class WorkoutGoal
    {
        public int Id { get; set; }
        public DateTime EndDate { get; set; }

        // relationship
        public int WorkoutId { get; set; }
        public Workout Workout { get; set; }
        public int GoalId { get; set; }
        public Exercise Goal { get; set; }
    }
}
