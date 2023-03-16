using mefit_backend.models.domain;
using Microsoft.EntityFrameworkCore;

namespace mefit_backend.models
{
    public class MeFitDbContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<FitnessProgram> FitnessPrograms { get; set; } 
        public DbSet<Goal> Goals { get; set; }
        public DbSet<Impairment> Impairments { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<WorkoutGoal> WorkoutGoals { get; set; }
        public DbSet<WorkoutExercise> WorkoutExercises { get; set; }

        public DbSet<FitnessProgramGoal> FitnessProgramGoals  { get; set; }
        public MeFitDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>().HasData(
            new Address { Id = 1, AdressLine = "Storgatan 1", PostalCode = 12345, City = "Vaxjö", Country = "Sweden" });

            modelBuilder.Entity<Exercise>().HasData(new Exercise
            {
                Id = 1,
                Name = "Pushup",
                Description = "Push up with arms",
                ImageLink = "some link",
                VideoLink = "some link",
                TargetMuscleGroup = "Biceps"
            });

            modelBuilder.Entity<FitnessProgram>().HasData(new FitnessProgram { Id = 1, Name = "Program 1", Category = "Upper body" });

            modelBuilder.Entity<Goal>().HasData(new Goal {Id = 1, Achieved = false, StartDate = new DateTime(), EndDate = new DateTime(), ProfileId = 1});

            modelBuilder.Entity<Impairment>().HasData(new Impairment { Id = 1, Description = "Cannot use legs", Name = "I have no legs" });

            modelBuilder.Entity<Profile>().HasData(new Profile { Id = 1, keycloakId = "1", Height = 180, Weight = 80 });

            modelBuilder.Entity<User>().HasData(new User { Id = 1, Email = "Test@test.com", FirstName = "Urban", LastName = "Svensson", Password = "password", IsAdmin = true, IsContributor = true});

            modelBuilder.Entity<Workout>().HasData(new Workout { Id = 1, Name = "Power Hour", Complete = false, Type = "Hardcore" });

            modelBuilder.Entity<WorkoutExercise>().HasData(new WorkoutExercise { Id = 1, ExerciseId = 1, WorkoutId = 1, Set = 5, Repetition = 3 });

            modelBuilder.Entity<WorkoutGoal>().HasData(new WorkoutGoal { Id = 1, GoalId = 1, WorkoutId = 1, StartDate = new DateTime(), EndDate = new DateTime() });

            modelBuilder.Entity<FitnessProgramGoal>().HasData(new FitnessProgramGoal { Id = 1, GoalId = 1, FitnessProgramId = 1, StartDate = new DateTime(), EndDate = new DateTime() });

            modelBuilder.Entity<Impairment>()
                .HasMany(impairment => impairment.Profiles)
                .WithMany(profile => profile.Impairments)
                .UsingEntity<Dictionary<string, object>>(
                    "ImpairmentProfile",
                    r => r.HasOne<Profile>().WithMany().HasForeignKey("ProfileId"),
                    l => l.HasOne<Impairment>().WithMany().HasForeignKey("ImpairmentId"),
                    je =>
                    {
                        je.HasKey("ProfileId", "ImpairmentId");
                        je.HasData(new { ProfileId = 1, ImpairmentId = 1 });
                    }
                );

            modelBuilder.Entity<Impairment>()
                .HasMany(impairment => impairment.Exercises)
                .WithMany(exercise => exercise.Impairments)
                .UsingEntity<Dictionary<string, object>>(
                    "ImpairmentExercise",
                    r => r.HasOne<Exercise>().WithMany().HasForeignKey("ExerciseId"),
                    l => l.HasOne<Impairment>().WithMany().HasForeignKey("ImpairmentId"),
                    je =>
                    {
                        je.HasKey("ExerciseId", "ImpairmentId");
                        je.HasData(new { ExerciseId = 1, ImpairmentId = 1 });
                    }
                );

            //modelBuilder.Entity<Workout>()
            //    .HasMany(workout => workout.Exercises)
            //    .WithMany(exercise => exercise.Workouts)
            //    .UsingEntity<Dictionary<string, object>>(
            //        "WorkoutExercise",
            //        r => r.HasOne<Exercise>().WithMany().HasForeignKey("ExerciseId"),
            //        l => l.HasOne<Workout>().WithMany().HasForeignKey("WorkoutId"),
            //        je =>
            //        {
            //            je.HasKey("ExerciseId", "WorkoutId");
            //            je.HasData(new { ExerciseId = 1, WorkoutId = 1, set = 5});
            //        }
            //    );

            modelBuilder.Entity<Workout>()
                .HasMany(workout => workout.FitnessPrograms)
                .WithMany(fitnessprogram => fitnessprogram.Workouts)
                .UsingEntity<Dictionary<string, object>>(
                    "WorkoutFitnessProgram",
                    r => r.HasOne<FitnessProgram>().WithMany().HasForeignKey("FitnessProgramId"),
                    l => l.HasOne<Workout>().WithMany().HasForeignKey("WorkoutId"),
                    je =>
                    {
                        je.HasKey("FitnessProgramId", "WorkoutId");
                        je.HasData(new { FitnessProgramId = 1, WorkoutId = 1});
                    }
                );
        }

    }
}
