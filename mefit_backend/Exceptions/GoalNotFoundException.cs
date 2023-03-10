namespace mefit_backend.Exceptions
{
    public class GoalNotFoundException : Exception
    {
        public GoalNotFoundException(int id) : base($"Goal with id {id} was not found")
        {

        }
    }
}
