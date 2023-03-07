namespace mefit_backend.models.domain
{
    public class Impairment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public ICollection<Profile> Profiles { get; set; }
        public ICollection<Exercise> Exercises { get; set; }
    }
}
