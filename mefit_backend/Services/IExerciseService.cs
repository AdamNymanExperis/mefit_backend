using mefit_backend.models.domain;

namespace mefit_backend.Service
{
    public interface IExerciseService
    {
        public Task<IEnumerable<Exercise>> GetExercises();
        public Task<Exercise> GetExerciseById(int id);

        public Task<Exercise> CreateExercise(Exercise exercise);
        public Task<Exercise> UpdateExercise(Exercise exercise);
        public Task DeleteExercise(int id);
    }
}
