namespace mefit_backend.models.domain
{
    public class Impairment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        ICollection<Profile> Profiles { get; set; }
        ICollection<Exercise> Exercises { get; set; }
    }
}
