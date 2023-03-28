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

            modelBuilder.Entity<Exercise>().HasData(
                new Exercise {
                    Id = 1,
                    Name = "Push-ups",
                    Description = "Beginning from the prone position. Then raise and lower your body using your arms",
                    ImageLink = "https://www.fitnesseducation.edu.au/wp-content/uploads/2017/03/Pushups.jpg",
                    VideoLink = "https://www.youtube.com/watch?v=IODxDxX7oi4",
                    TargetMuscleGroup = "pectoral muscles, triceps, and anterior deltoids"
                },
                new Exercise
                { 
                    Id = 2,
                    Name = "sit-ups",
                    Description = "It begins with lying with the back on the floor, and then elevating both the upper and lower vertebrae from the floor until everything superior to the buttocks is not touching the ground.",
                    ImageLink = "https://media1.popsugar-assets.com/files/thumbor/H-fK4_7_zgVsPw4eSV584Jm5aN4/fit-in/2048xorig/filters:format_auto-!!-:strip_icc-!!-/2017/08/30/908/n/1922729/6405c6aa84236a1b_Core-Full-Sit-Ups/i/Sit-Ups.jpg",
                    VideoLink = "https://www.youtube.com/watch?v=jDwoBqPH0jk",
                    TargetMuscleGroup = "abdominal muscles"
                },
                new Exercise
                {
                    Id = 3,
                    Name = "Pull-ups",
                    Description = "The pull-up is a closed-chain movement where the body is suspended by the hands, gripping a bar or other implement at a distance typically wider than shoulder-width, and pulled up.",
                    ImageLink = "https://www.gymlivet.com/wp-content/uploads/2015/08/pullups-gymlivet.jpg",
                    VideoLink = "https://www.youtube.com/watch?v=eGo4IYlbE5g",
                    TargetMuscleGroup = " latissimus dorsi, trapezius, and biceps brachii."
                },
                new Exercise
                {
                    Id = 4,
                    Name = "Squats",
                    Description = "A squat is a strength exercise in which the trainee lowers their hips from a standing position and then stands back up. During the descent, the hip and knee joints flex while the ankle joint dorsiflexes; conversely the hip and knee joints extend and the ankle joint plantarflexes when standing up.",
                    ImageLink = "https://images.bonnier.cloud/files/ifo/production/20221017085114/Squats2.jpg",
                    VideoLink = "https://www.youtube.com/watch?v=YaXPRqUwItQ",
                    TargetMuscleGroup = "the quadriceps femoris, the adductor magnus, and the gluteus maximus."
                },
                new Exercise
                {
                    Id = 5,
                    Name = "Clean and Jerk",
                    Description = "The clean and jerk is a composite of two weightlifting movements, most often performed with a barbell: the clean and the jerk.",
                    ImageLink = "https://i.ytimg.com/vi/PjY1rH4_MOA/maxresdefault.jpg",
                    VideoLink = "https://www.youtube.com/watch?v=PjY1rH4_MOA",
                    TargetMuscleGroup = "Whole body"
                },
                new Exercise
                {
                    Id = 6,
                    Name = "Deadlift",
                    Description = "The deadlift is a weight training exercise in which a loaded barbell or bar is lifted off the ground to the level of the hips, torso perpendicular to the floor, before being placed back on the ground. It is one of the three powerlifting exercises, along with the squat and bench press.",
                    ImageLink = "https://i.ytimg.com/vi/1ZXobu7JvvE/maxresdefault.jpg",
                    VideoLink = "https://www.youtube.com/watch?v=1ZXobu7JvvE",
                    TargetMuscleGroup = "the gluteus maximus and gluteus minimus"
                },
                new Exercise
                {
                    Id = 7,
                    Name = "Bench press",
                    Description = " A weight training exercise where the trainee presses a weight upwards while lying on a weight training bench.",
                    ImageLink = "https://www.inspireusafoundation.org/wp-content/uploads/2022/06/barbell-bench-press-benefits-1024x576.jpg",
                    VideoLink = "https://www.youtube.com/watch?v=rT7DgCr-3pg",
                    TargetMuscleGroup = "the pectoralis major, the anterior deltoids, and the triceps"
                }

            );

            modelBuilder.Entity<FitnessProgram>().HasData(
                new FitnessProgram 
                { 
                    Id = 1,
                    Name = "Arm Program",
                    Category = "Upper body" 
                },
                new FitnessProgram
                {
                    Id = 2,
                    Name = "Legs Program",
                    Category = "Lower body"
                },
                new FitnessProgram
                {
                    Id = 3,
                    Name = "Chest Program",
                    Category = "Upper body"
                },
                new FitnessProgram
                {
                    Id = 4,
                    Name = "Back Program",
                    Category = "Upper body"
                }
            );

            modelBuilder.Entity<Goal>().HasData(new Goal {Id = 1, Achieved = true, title = "Goal 1",  start = new DateTime(), end = new DateTime(), ProfileId = 1});

            modelBuilder.Entity<Impairment>().HasData(
                new Impairment 
                { 
                    Id = 1,
                    Description = "Having problems with exercises involving the arms",
                    Name = "Arms Impairments"
                },
                new Impairment
                {
                    Id = 2,
                    Description = "Having problems with exercises involving the legs",
                    Name = "Legs Impairments"
                },
                new Impairment
                {
                    Id = 3,
                    Description = "Having problems with exercises involving the back",
                    Name = "Back Impairments"
                }
            );

            modelBuilder.Entity<Profile>().HasData(new Profile { Id = 1, keycloakId = "5289cc70-cc80-42ee-9875-f4f685b75f5b", Height = 180, Weight = 80 });

            modelBuilder.Entity<User>().HasData(new User { Id = 1, Email = "Test@test.com", FirstName = "Urban", LastName = "Svensson", Password = "password", IsAdmin = true, IsContributor = true});

            modelBuilder.Entity<Workout>().HasData(
                new Workout 
                {
                    Id = 1,
                    Name = "Power Lift",
                    Complete = false,
                    Type = "Hardcore"
                },
                new Workout
                {
                    Id = 2,
                    Name = "Chest Day",
                    Complete = false,
                    Type = "Hardcore"
                }
            );

            modelBuilder.Entity<WorkoutExercise>().HasData(
                new WorkoutExercise 
                {
                    Id = 1,
                    ExerciseId = 4,
                    WorkoutId = 1,
                    Set = 5,
                    Repetition = 3 
                },
                new WorkoutExercise
                {
                    Id = 2,
                    ExerciseId = 6,
                    WorkoutId = 1,
                    Set = 5,
                    Repetition = 3
                },
                new WorkoutExercise
                {
                    Id = 3,
                    ExerciseId = 7,
                    WorkoutId = 1,
                    Set = 5,
                    Repetition = 3
                },
                new WorkoutExercise
                {
                    Id = 4,
                    ExerciseId = 1,
                    WorkoutId = 2,
                    Set = 5,
                    Repetition = 3
                },
                new WorkoutExercise
                {
                    Id = 5,
                    ExerciseId = 7,
                    WorkoutId = 2,
                    Set = 5,
                    Repetition = 3
                }
            );

            modelBuilder.Entity<WorkoutGoal>().HasData(new WorkoutGoal { Id = 1, GoalId = 1, WorkoutId = 1, start = new DateTime(), end = new DateTime() });

            modelBuilder.Entity<FitnessProgramGoal>().HasData(new FitnessProgramGoal { Id = 1, GoalId = 1, FitnessProgramId = 1, start = new DateTime(), end = new DateTime() });

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
                        je.HasData(
                            new { ExerciseId = 1, ImpairmentId = 1 },
                            new { ExerciseId = 1, ImpairmentId = 3 },
                            new { ExerciseId = 2, ImpairmentId = 3 },
                            new { ExerciseId = 3, ImpairmentId = 1 },
                            new { ExerciseId = 3, ImpairmentId = 3 },
                            new { ExerciseId = 4, ImpairmentId = 2 },
                            new { ExerciseId = 4, ImpairmentId = 3 },
                            new { ExerciseId = 5, ImpairmentId = 1 },
                            new { ExerciseId = 5, ImpairmentId = 2 },
                            new { ExerciseId = 5, ImpairmentId = 3 },
                            new { ExerciseId = 6, ImpairmentId = 1 },
                            new { ExerciseId = 6, ImpairmentId = 2 },
                            new { ExerciseId = 6, ImpairmentId = 3 },
                            new { ExerciseId = 7, ImpairmentId = 1 }
                         );
                    }
                );

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
                        je.HasData(
                            new { FitnessProgramId = 3, WorkoutId = 1},
                            new { FitnessProgramId = 3, WorkoutId = 2 }
                        );
                    }
                );
        }

    }
}
