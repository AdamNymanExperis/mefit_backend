using mefit_backend.models.domain;

namespace mefit_backend.models.DTO.ExerciseDtos
{
    public class GetExerciseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TargetMuscleGroup { get; set; }
        public string ImageLink { get; set; }
        public string VideoLink { get; set; }

        public List<string> Impairments { get; set; }
        public List<string> WorkoutExercise { get; set; }
    }
}
