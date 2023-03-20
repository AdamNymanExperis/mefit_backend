namespace mefit_backend.Models.DTO.Goal
{
    public class CreateGoalDTO
    {
        public string title { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public bool Achieved { get; set; }

        // relationship 
        public int ProfileId { get; set; }
    }
}
