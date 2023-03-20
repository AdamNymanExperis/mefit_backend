using mefit_backend.models.domain;

namespace mefit_backend.Models.DTO.Goal
{
    public class GetGoalDTO
    {
        public int Id { get; set; }
        public string title { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public bool Achieved { get; set; }

        // relationship 
        public int ProfileId { get; set; }
        public List<string> FitnessProgramGoals { get; set; }
        public List<string> WorkoutGoals { get; set; }
    }
}
