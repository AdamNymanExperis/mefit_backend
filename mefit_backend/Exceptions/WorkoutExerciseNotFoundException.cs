namespace mefit_backend.Exceptions
{
    public class WorkoutExerciseNotFoundException : Exception
    {
        public WorkoutExerciseNotFoundException(int id) : base($"WorkoutExercise with id {id} was not found")
        {

        }
    }
}
