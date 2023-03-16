﻿namespace mefit_backend.models.domain
{
    public class Goal
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Achieved { get; set; }

        // relationship 
        public int ProfileId { get; set; }
        public Profile Profile { get; set; }
        public ICollection<FitnessProgramGoal> FitnessProgramGoals { get; set; }
        public ICollection<WorkoutGoal> WorkoutGoals { get; set; }
    }
}
