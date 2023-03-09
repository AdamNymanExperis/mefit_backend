namespace mefit_backend.models.DTO
{
    public class PutExerciseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TargetMuscleGroup { get; set; }
        public string ImageLink { get; set; }
        public string VideoLink { get; set; }
    }
}
