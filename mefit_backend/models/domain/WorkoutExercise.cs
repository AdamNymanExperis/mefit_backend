using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mefit_backend.models.domain
{
    public class WorkoutExercise
    {
        public int Id { get; set; }
        public int Set { get; set; }
        public int Repetition { get; set; }
        
        // relationship
        public int WorkoutId { get; set; }
        public Workout Workout { get; set; }
        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }

    }
}
