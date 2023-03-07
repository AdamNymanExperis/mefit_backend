namespace mefit_backend.models.domain
{
    public class Profile
    {
        public int Id { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }

        // relationships
        public int user_id { get; set; }
        public User User { get; set; }

        public int Address_id { get; set; }
        public Address Address { get; set; }

        public ICollection<Goal> Goals { get; set; }
        public ICollection<Impairment> Impairments { get; set; }
    }
}
