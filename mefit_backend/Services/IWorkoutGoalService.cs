using mefit_backend.models.domain;

namespace mefit_backend.Services
{
    public interface IWorkoutGoalService
    {
        public Task<WorkoutGoal> GetWorkoutGoalById(int id);
        public Task<WorkoutGoal> CreateWorkoutGoal(WorkoutGoal workoutGoal);
        public Task<WorkoutGoal> UpdateWorkoutGoal(WorkoutGoal workoutGoal);
        public Task DeleteWorkoutGoal(int id);
    }
}
