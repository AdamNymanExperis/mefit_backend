using mefit_backend.models.domain;

namespace mefit_backend.Services
{
    public interface IWorkoutExerciseService
    {
        public Task<WorkoutExercise> GetWorkoutExerciseById(int id);
        public Task<WorkoutExercise> CreateWorkoutExercise(WorkoutExercise workoutExercise);
        public Task<WorkoutExercise> UpdateWorkoutExercise(WorkoutExercise workoutExercise);
        public Task DeleteWorkoutExercise(int id);
    }
}
