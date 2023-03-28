namespace mefit_backend.models.DTO.ExerciseDtos
{
    public class PostExerciseDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string TargetMuscleGroup { get; set; }
        public string ImageLink { get; set; }
        public string VideoLink { get; set; }
    }
}
