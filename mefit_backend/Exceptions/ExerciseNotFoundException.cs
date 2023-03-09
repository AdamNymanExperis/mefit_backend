namespace mefit_backend.Exceptions
{
    public class ExerciseNotFoundException : Exception
    {
        public ExerciseNotFoundException(int id) : base($"Exercise with id {id} was not found")
        {

        }
    }
}
