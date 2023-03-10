namespace mefit_backend.Exceptions
{
    public class ImpairmentNotFoundException : Exception
    {
        public ImpairmentNotFoundException(int id) : base($"Impairment with id {id} was not found")
        {

        }
    }
}
