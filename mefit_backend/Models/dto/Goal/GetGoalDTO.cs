using mefit_backend.models.domain;

namespace mefit_backend.Models.DTO.Goal
{
    public class GetGoalDTO
    {
        public int Id { get; set; }
        public DateTime EndDate { get; set; }
        public bool Achieved { get; set; }

        // relationship 
        public int ProfileId { get; set; }
        public List<string> FitnessPrograms { get; set; }
        public List<string> Workouts { get; set; }
    }
}
