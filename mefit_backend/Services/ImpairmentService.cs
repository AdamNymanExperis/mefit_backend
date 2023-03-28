using mefit_backend.Exceptions;
using mefit_backend.models;
using mefit_backend.models.domain;
using mefit_backend.models.DTO;
using Microsoft.EntityFrameworkCore;

namespace mefit_backend.Services
{
    public class ImpairmentService : IImpairmentService
    {
        private readonly MeFitDbContext _context;

        public ImpairmentService(MeFitDbContext context)
        {
            _context = context;
        }

        public async Task<Impairment> CreateImpairment(Impairment impairment)
        {
            _context.Impairments.Add(impairment);

            await _context.SaveChangesAsync();

            return impairment;
        }

        public async Task DeleteImpairment(int id)
        {
            var impairment = await _context.Impairments.FindAsync(id);

            if (impairment == null)
            {
                throw new ExerciseNotFoundException(id);
            }
            _context.Impairments.Remove(impairment);

            await _context.SaveChangesAsync();
        }

        public async Task<Impairment> GetImpairmentById(int id)
        {
            var impairment = await _context.Impairments.Include(x => x.Profiles).Include(x => x.Exercises).FirstOrDefaultAsync(x => x.Id == id);

            if (impairment == null)
            {
                throw new Exception();
            }
            return impairment;
        }

        public async Task<IEnumerable<Impairment>> GetImpairments()
        {
            return await _context.Impairments.Include(x => x.Profiles).Include(x => x.Exercises).ToListAsync(); ;
        }

        public async Task<Impairment> UpdateImpairment(Impairment impairment)
        {
            var foundImpairment = await _context.Exercises.AnyAsync(x => x.Id == impairment.Id);

            if (!foundImpairment)
            {
                throw new ExerciseNotFoundException(impairment.Id);
            }
            _context.Entry(impairment).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return impairment;
        }
    }
}
