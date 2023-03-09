using mefit_backend.models.domain;

namespace mefit_backend.Models.DTO.WorkoutDtos
{
    public class AddWorkoutDTO
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public bool Complete { get; set; }
    }
}
