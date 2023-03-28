using AutoMapper;
using mefit_backend.Exceptions;
using mefit_backend.models;
using mefit_backend.models.domain;
using Microsoft.EntityFrameworkCore;

namespace mefit_backend.Services
{
    public class FitnessProgramGoalService : IFitnessProgramGoalService
    {
        private readonly MeFitDbContext _context;

        public FitnessProgramGoalService(MeFitDbContext context)
        {
            _context = context;
        }

        public async Task<FitnessProgramGoal> CreateFitnessProgramGoal(FitnessProgramGoal fitnessProgramGoal)
        {
            _context.FitnessProgramGoals.Add(fitnessProgramGoal);
            await _context.SaveChangesAsync();

            return fitnessProgramGoal;
        }

        public async Task DeleteFitnessProgramGoal(int id)
        {
            var fitnessProgramGoal = await _context.FitnessProgramGoals.FindAsync(id);
            if (fitnessProgramGoal == null)
            {
                throw new FitnessProgramGoalNotFoundException(id);
            }
            _context.FitnessProgramGoals.Remove(fitnessProgramGoal);
            await _context.SaveChangesAsync();
        }

        public async Task<FitnessProgramGoal> GetFitnessProgramGoalById(int id)
        {
            var fitnessProgramGoal = await _context.FitnessProgramGoals.FirstOrDefaultAsync(x => x.Id == id);
            if (fitnessProgramGoal == null)
            {
                throw new FitnessProgramGoalNotFoundException(id);
            }
            return fitnessProgramGoal;
        }

        public async Task<FitnessProgramGoal> UpdateFitnessProgramGoal(FitnessProgramGoal fitnessProgramGoal)
        {
            var foundFitnessProgramGoal = await _context.FitnessProgramGoals.AnyAsync(x => x.Id == fitnessProgramGoal.Id);
            if (!foundFitnessProgramGoal)
            {
                throw new FitnessProgramGoalNotFoundException(fitnessProgramGoal.Id);
            }
            _context.Entry(fitnessProgramGoal).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return fitnessProgramGoal;
        }
    }
}
