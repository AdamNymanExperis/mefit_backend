using mefit_backend.models.domain;

namespace mefit_backend.Services
{
    public interface IFitnessProgramGoalService
    {
        public Task<FitnessProgramGoal> GetFitnessProgramGoalById(int id);
        public Task<FitnessProgramGoal> CreateFitnessProgramGoal(FitnessProgramGoal fitnessProgramGoal);
        public Task<FitnessProgramGoal> UpdateFitnessProgramGoal(FitnessProgramGoal fitnessProgramGoal);
        public Task DeleteFitnessProgramGoal(int id);
    }
}
