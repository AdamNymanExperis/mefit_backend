using AutoMapper;
using mefit_backend.Exceptions;
using mefit_backend.models;
using mefit_backend.models.domain;
using Microsoft.EntityFrameworkCore;

namespace mefit_backend.Services
{
    public class GoalService : IGoalService
    {
        private readonly MeFitDbContext _context;

        public GoalService(MeFitDbContext context)
        {
            _context = context;
        }
        public async Task<Goal> CreateGoal(Goal goal)
        {
            _context.Goals.Add(goal);
            await _context.SaveChangesAsync();

            return goal;
        }

        public async Task DeleteGoal(int id)
        {
            var goal = await _context.Goals.FindAsync(id);
            if (goal == null)
            {
                throw new ProfileNotFoundException(id);
            }
            _context.Goals.Remove(goal);
            await _context.SaveChangesAsync();
        }

        public async Task<Goal> GetGoalById(int id)
        {
            var goal = await _context.Goals.Include(x => x.FitnessProgramGoals).Include(x => x.WorkoutGoals).FirstOrDefaultAsync(x => x.Id == id);
            if (goal == null)
            {
                throw new GoalNotFoundException(id);
            }
            return goal;
        }

        public async Task<Goal> UpdateGoal(Goal goal)
        {
            var foundGoal = await _context.Goals.AnyAsync(x => x.Id == goal.Id);
            if (!foundGoal)
            {
                throw new ProfileNotFoundException(goal.Id);
            }
            _context.Entry(goal).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return goal;
        }
    }
}
