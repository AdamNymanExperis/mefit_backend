namespace mefit_backend.models.domain
{
    public class Profile
    {
        public int Id { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }

        // relationships
        public string keycloakId { get; set; }

        public ICollection<Goal> Goals { get; set; }
        public ICollection<Impairment> Impairments { get; set; }

        //public int UserId { get; set; }
        //public User User { get; set; }


        //public int AddressId { get; set; }
        //public Address Address { get; set; }
    }
}
