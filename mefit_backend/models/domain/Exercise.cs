namespace mefit_backend.models.domain
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TargetMuscleGroup { get; set; }
        public string ImageLink { get; set; }
        public string VideoLink { get; set; }

        //Relationship
        public ICollection<Impairment> Impairments { get; set; }
        public ICollection<WorkoutExercise> WorkoutExercise { get; set; }
    }
}
