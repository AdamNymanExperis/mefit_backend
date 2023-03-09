using mefit_backend.models.domain;

namespace mefit_backend.Service
{
    public interface IExerciseService
    {
        public Task<IEnumerable<Exercise>> GetExercises();
    }
}
