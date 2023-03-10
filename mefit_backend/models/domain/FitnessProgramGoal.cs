namespace mefit_backend.models.domain
{
    public class FitnessProgramGoal
    {
        public int Id { get; set; }
        public DateTime EndDate { get; set; }

        // relationships
        public int GoalId { get; set; }
        public Goal Goal { get; set; }
        public int FitnessProgramId { get; set; }
        public FitnessProgram FitnessProgram { get; set; }
    }
}
