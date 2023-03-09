namespace mefit_backend.Exceptions
{
    public class WorkoutNotFoundException : Exception
    {

        public WorkoutNotFoundException(int id) : base($"Workout with id {id} was not found")
        {

        }
    }
}
