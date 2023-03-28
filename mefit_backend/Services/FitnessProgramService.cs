using AutoMapper;
using mefit_backend.Exceptions;
using mefit_backend.models;
using mefit_backend.models.domain;
using Microsoft.EntityFrameworkCore;

namespace mefit_backend.Services
{
    public class FitnessProgramService : IFitnessProgramService
    {
        private readonly MeFitDbContext _context;

        public FitnessProgramService(MeFitDbContext context)
        {
            _context = context;
        }

        public async Task<FitnessProgram> CreateFitnessProgram(FitnessProgram fitnessProgram)
        {
            _context.FitnessPrograms.Add(fitnessProgram);
            await _context.SaveChangesAsync();

            return fitnessProgram;
        }

        public async Task DeleteFitnessProgram(int id)
        {
            var fitnessProgram = await _context.FitnessPrograms.FindAsync(id);

            if (fitnessProgram == null)
            {
                throw new FitnessProgramNotFoundException(id);
            }
            _context.FitnessPrograms.Remove(fitnessProgram);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<FitnessProgram>> GetFitnessProgram()
        {
            return await _context.FitnessPrograms.Include(x => x.Workouts).Include(x => x.FitnessProgramGoals).ToListAsync();
        }

        public async Task<FitnessProgram> GetFitnessProgramById(int id)
        {
            var fitnessProgram = await _context.FitnessPrograms.Include(x => x.Workouts).Include(x => x.FitnessProgramGoals).FirstOrDefaultAsync(x => x.Id == id);

            if (fitnessProgram == null)
            {
                throw new FitnessProgramNotFoundException(id);
            }
            return fitnessProgram;
        }

        public async Task<FitnessProgram> UpdateFitnessProgram(FitnessProgram fitnessProgram)
        {
            var foundFitnessProgram = await _context.Exercises.AnyAsync(x => x.Id == fitnessProgram.Id);

            if (!foundFitnessProgram)
            {
                throw new FitnessProgramNotFoundException(fitnessProgram.Id);
            }
            _context.Entry(fitnessProgram).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return fitnessProgram;
        }

        public async Task UpdateWorkoutsInFitnessProgram(int[] workoutIds, int fitnessprogramId)
        {
            var checkFitnessProgram = await _context.FitnessPrograms.FindAsync(fitnessprogramId);
            if (checkFitnessProgram == null)
                throw new FitnessProgramNotFoundException(fitnessprogramId);

            List<Workout> workouts = workoutIds
                .ToList()
                .Select(x => _context.Workouts
                .Where(s => s.Id == x).First())
                .ToList();

            FitnessProgram fitnessProgram = await _context.FitnessPrograms
                .Where(x => x.Id == fitnessprogramId)
                .FirstAsync();

            fitnessProgram.Workouts = workouts;
            _context.Entry(fitnessProgram).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }
    }
}
