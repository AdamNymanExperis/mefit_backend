using mefit_backend.models;
using mefit_backend.models.domain;
using Microsoft.EntityFrameworkCore;

namespace mefit_backend.Service
{
    public class ExerciseService : IExerciseService
    {
        private readonly MeFitDbContext _context;

        public ExerciseService(MeFitDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Exercise>> GetExercises()
        {
            return await _context.Exercises.ToListAsync();
        }
    }
}
