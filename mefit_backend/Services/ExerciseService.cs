using AutoMapper;
using mefit_backend.Exceptions;
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

        public async Task<Exercise> CreateExercise(Exercise exercise) 
        {
            _context.Exercises.Add(exercise);
            await _context.SaveChangesAsync();

            return exercise;
        }

        public async Task DeleteExercise(int id) 
        {
            var exercise = await _context.Exercises.FindAsync(id);

            if (exercise == null)
            {
                throw new ExerciseNotFoundException(id);
            }
            _context.Exercises.Remove(exercise);
            await _context.SaveChangesAsync();
        }

        public async Task<Exercise> GetExerciseById(int id) 
        {
            var exercise = await _context.Exercises.Include(x => x.WorkoutExercise).Include(x => x.Impairments).FirstOrDefaultAsync(x => x.Id == id);

            if (exercise == null)
            {
                throw new Exception();
            }
            return exercise;
        }

        public async Task<IEnumerable<Exercise>> GetExercises() 
        {
            return await _context.Exercises.Include(x => x.WorkoutExercise).Include(x => x.Impairments).ToListAsync();
        }

        public async Task<Exercise> UpdateExercise(Exercise exercise) 
        {
            var foundExercise = await _context.Exercises.AnyAsync(x => x.Id == exercise.Id);

            if (!foundExercise)
            {
                throw new ExerciseNotFoundException(exercise.Id);
            }
            _context.Entry(exercise).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return exercise;
        }

        public async Task UpdateImpairmentsInExercise(int[] impairmentIds, int exerciseId)
        {
            var checkExercise = await _context.Exercises.FindAsync(exerciseId);
            if (checkExercise == null)
                throw new ExerciseNotFoundException(exerciseId);

            List<Impairment> impairments = impairmentIds
                .ToList()
                .Select(x => _context.Impairments
                .Where(s => s.Id == x).First())
                .ToList();

            Exercise exercise = await _context.Exercises
                .Where(x => x.Id == exerciseId)
                .FirstAsync();

            exercise.Impairments = impairments;
            _context.Entry(exercise).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }
    }
}
