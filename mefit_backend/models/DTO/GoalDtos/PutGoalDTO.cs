namespace mefit_backend.Models.DTO.Goal
{
    public class PutGoalDTO
    {
        public int Id { get; set; }
        public DateTime EndDate { get; set; }
        public bool Achieved { get; set; }

        // relationship 
        public int ProfileId { get; set; }
    }
}
