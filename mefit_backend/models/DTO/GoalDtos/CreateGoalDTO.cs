namespace mefit_backend.Models.DTO.Goal
{
    public class CreateGoalDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Achieved { get; set; }

        // relationship 
        public int ProfileId { get; set; }
    }
}
