namespace mefit_backend.models.domain
{
    public class FitnessProgram
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }

        // Relationship
        public ICollection<Workout> Workouts { get; set; }
        public ICollection<FitnessProgramGoal> FitnessProgramGoals { get; set; }
    }
}
