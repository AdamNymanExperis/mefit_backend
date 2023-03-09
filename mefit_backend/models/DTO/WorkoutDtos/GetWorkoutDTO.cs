using mefit_backend.models.domain;

namespace mefit_backend.Models.DTO.WorkoutDtos
{
    public class GetWorkoutDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool Complete { get; set; }

        //Relationship
        public List<string> WorkoutExercises { get; set; }
        public List<string> WorkoutGoals { get; set; }
        public List<string> FitnessPrograms { get; set; }
    }
}
