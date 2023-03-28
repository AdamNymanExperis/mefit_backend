using mefit_backend.models.domain;

namespace mefit_backend.Services
{
    public interface IFitnessProgramService
    {
        public Task<IEnumerable<FitnessProgram>> GetFitnessProgram();
        public Task<FitnessProgram> GetFitnessProgramById(int id);

        public Task<FitnessProgram> CreateFitnessProgram(FitnessProgram fitnessProgram);
        public Task<FitnessProgram> UpdateFitnessProgram(FitnessProgram fitnessProgram);
        public Task DeleteFitnessProgram(int id);

        public Task UpdateWorkoutsInFitnessProgram(int[] workoutIds, int fitnessprogramId);
    }
}
