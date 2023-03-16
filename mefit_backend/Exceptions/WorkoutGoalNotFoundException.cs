namespace mefit_backend.Exceptions
{
    public class WorkoutGoalNotFoundException : Exception
    {
        public WorkoutGoalNotFoundException(int id) : base($"WorkoutGoal with id {id} was not found")
        {

        }
    }
}
