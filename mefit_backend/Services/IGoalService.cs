using mefit_backend.models.domain;

namespace mefit_backend.Services
{
    public interface IGoalService
    {
        public Task<Goal> GetGoalById(int id);
        public Task<Goal> CreateGoal(Goal goal);
        public Task<Goal> UpdateGoal(Goal goal);
        public Task DeleteGoal(int id);
    }
}
