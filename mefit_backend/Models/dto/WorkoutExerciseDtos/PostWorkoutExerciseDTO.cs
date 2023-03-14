namespace mefit_backend.Models.dto.WorkoutExerciseDtos
{
    public class PostWorkoutExerciseDTO
    {
        public int Set { get; set; }
        public int Repetition { get; set; }
        public int ExerciseId { get; set; }
        public int WorkoutId { get; set; }
    }
}
