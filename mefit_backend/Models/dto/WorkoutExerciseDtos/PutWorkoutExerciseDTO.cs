namespace mefit_backend.Models.dto.WorkoutExerciseDtos
{
    public class PutWorkoutExerciseDTO
    {
        public int Id { get; set; }
        public int Set { get; set; }
        public int Repetition { get; set; }
        public int ExerciseId { get; set; }
    }
}
