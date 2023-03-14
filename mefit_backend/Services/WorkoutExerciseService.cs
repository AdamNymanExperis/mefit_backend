using AutoMapper;
using mefit_backend.Exceptions;
using mefit_backend.models;
using mefit_backend.models.domain;
using Microsoft.EntityFrameworkCore;

namespace mefit_backend.Services
{
    public class WorkoutExerciseService : IWorkoutExerciseService
    {
        private readonly MeFitDbContext _context;

        public WorkoutExerciseService(MeFitDbContext context)
        {
            _context = context;
        }

        public async Task<WorkoutExercise> CreateWorkoutExercise(WorkoutExercise workoutExercise)
        {
            _context.WorkoutExercises.Add(workoutExercise);
            await _context.SaveChangesAsync();

            return workoutExercise;
        }

        public async Task DeleteWorkoutExercise(int id)
        {
            var workoutExercise = await _context.WorkoutExercises.FindAsync(id);
            if (workoutExercise == null)
            {
                throw new WorkoutExerciseNotFoundException(id);
            }
            _context.WorkoutExercises.Remove(workoutExercise);
            await _context.SaveChangesAsync();
        }

        public async Task<WorkoutExercise> GetWorkoutExerciseById(int id)
        {
            var workoutExercise = await _context.WorkoutExercises.FirstOrDefaultAsync(x => x.Id == id);
            if (workoutExercise == null)
            {
                throw new WorkoutExerciseNotFoundException(id);
            }
            return workoutExercise;
        }

        public async Task<WorkoutExercise> UpdateWorkoutExercise(WorkoutExercise workoutExercise)
        {
            var foundWorkoutExercise = await _context.WorkoutExercises.AnyAsync(x => x.Id == workoutExercise.Id);
            if (!foundWorkoutExercise)
            {
                throw new ProfileNotFoundException(workoutExercise.Id);
            }
            _context.Entry(workoutExercise).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return workoutExercise;
        }
    }
}
