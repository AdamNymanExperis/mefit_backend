namespace mefit_backend.models.domain
{
    public class Goal
    {
        public int Id { get; set; }
        public DateTime End_date { get; set; }
        public bool Achieved { get; set; }

        // relationship 
        public int profile_id { get; set; }
        public Profile Profile { get; set; }
    }
}
