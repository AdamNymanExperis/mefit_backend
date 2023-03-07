namespace mefit_backend.models.domain
{
    public class Workout
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool Complete { get; set; }

        //Relationship
        public ICollection<Exercise> Exercises { get; set; }
        public ICollection<Goal> Goals { get; set; }
        public ICollection<FitnessProgram> FitnessPrograms { get; set; }
    }
}
