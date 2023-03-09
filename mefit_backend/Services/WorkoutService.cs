using mefit_backend.Exceptions;
using mefit_backend.models;
using mefit_backend.models.domain;
using Microsoft.EntityFrameworkCore;

namespace mefit_backend.Services
{
    public class WorkoutService : IWorkoutService
    {
        private readonly MeFitDbContext _context;
        public WorkoutService(MeFitDbContext context) 
        {
            _context = context;
        }
        public async Task<Workout> AddWorkout(Workout workout)
        {
            _context.Workouts.Add(workout);
            await _context.SaveChangesAsync();

            return workout;
        }

        public async Task DeleteWorkout(int id)
        {
            var workout = await _context.Workouts.FindAsync(id);
            if (workout == null)
            {
                throw new WorkoutNotFoundException(id);
            }

            _context.Workouts.Remove(workout);
            await _context.SaveChangesAsync();
        }

        public async Task<Workout> GetWorkoutById(int id)
        {
            var workout = await _context.Workouts.Include(x => x.WorkoutGoals).Include(x => x.FitnessPrograms).Include(x => x.WorkoutExercises).FirstOrDefaultAsync(x => x.Id == id);

            if (workout == null)
            {
                throw new WorkoutNotFoundException(id);
            }

            return workout;
        }

        public async Task<Workout> UpdateWorkout(Workout workout)
        {
            var foundWorkout = await _context.Workouts.AnyAsync(x => x.Id == workout.Id);
            if (!foundWorkout)
            {
                throw new WorkoutNotFoundException(workout.Id);
            }
            _context.Entry(workout).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return workout;
        }
    }
}
