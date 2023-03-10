using mefit_backend.models.domain;

namespace mefit_backend.Services
{
    public interface IWorkoutService
    {
        Task<Workout> GetWorkoutById(int id);
        Task<Workout> AddWorkout(Workout workout);
        Task DeleteWorkout(int id);
        Task<Workout> UpdateWorkout(Workout workout);
    }
}
