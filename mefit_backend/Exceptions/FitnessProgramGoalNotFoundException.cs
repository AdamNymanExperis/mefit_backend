namespace mefit_backend.Exceptions
{
    public class FitnessProgramGoalNotFoundException : Exception
    {
        public FitnessProgramGoalNotFoundException(int id) : base($"FitnessProgramGoal with id {id} was not found")
        {

        }
    }
}
