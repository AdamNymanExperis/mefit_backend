namespace mefit_backend.Exceptions
{
    public class FitnessProgramNotFoundException : Exception
    {
        public FitnessProgramNotFoundException(int id) : base($"Fitness Program with id {id} was not found")
        {

        }
    }
}
