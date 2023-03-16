using AutoMapper;
using mefit_backend.Exceptions;
using mefit_backend.models;
using mefit_backend.models.domain;
using Microsoft.EntityFrameworkCore;

namespace mefit_backend.Services
{
    public class WorkoutGoalService : IWorkoutGoalService
    {
        private readonly MeFitDbContext _context;

        public WorkoutGoalService(MeFitDbContext context)
        {
            _context = context;
        }

        public async Task<WorkoutGoal> CreateWorkoutGoal(WorkoutGoal workoutGoal)
        {
            _context.WorkoutGoals.Add(workoutGoal);
            await _context.SaveChangesAsync();

            return workoutGoal;
        }

        public async Task DeleteWorkoutGoal(int id)
        {
            var workoutGoal = await _context.WorkoutGoals.FindAsync(id);
            if (workoutGoal == null)
            {
                throw new WorkoutGoalNotFoundException(id);
            }
            _context.WorkoutGoals.Remove(workoutGoal);
            await _context.SaveChangesAsync();
        }

        public async Task<WorkoutGoal> GetWorkoutGoalById(int id)
        {
            var workoutGoal = await _context.WorkoutGoals.FirstOrDefaultAsync(x => x.Id == id);
            if (workoutGoal == null)
            {
                throw new WorkoutGoalNotFoundException(id);
            }
            return workoutGoal;
        }

        public async Task<WorkoutGoal> UpdateWorkoutGoal(WorkoutGoal workoutGoal)
        {
            var foundWorkoutGoal = await _context.WorkoutGoals.AnyAsync(x => x.Id == workoutGoal.Id);
            if (!foundWorkoutGoal)
            {
                throw new ProfileNotFoundException(workoutGoal.Id);
            }
            _context.Entry(workoutGoal).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return workoutGoal;
        }
    }
}
