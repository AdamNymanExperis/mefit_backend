namespace mefit_backend.Models.DTO.WorkoutDtos
{
    public class PutWorkoutDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool Complete { get; set; }
    }
}
