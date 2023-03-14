namespace mefit_backend.Models.dto.WorkoutExerciseDtos
{
    public class GetWorkoutExerciseDTO
    {
        public int Id { get; set; }
        public int Set { get; set; }
        public int Repetition { get; set; }
        public string Exercise { get; set; }
    }
}
