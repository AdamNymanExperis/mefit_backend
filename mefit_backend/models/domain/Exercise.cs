namespace mefit_backend.models.domain
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Target_muscle_group { get; set; }
        public string Image_link { get; set; }
        public string Video_link { get; set; }

        //Relationship
        public ICollection<Impairment> Impairments { get; set; }
        public ICollection<Workout> Workouts { get; set; }
    }
}
