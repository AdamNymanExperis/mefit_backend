namespace mefit_backend.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(int id) : base($"User with id {id} was not found")
        {

        }
    }
}
