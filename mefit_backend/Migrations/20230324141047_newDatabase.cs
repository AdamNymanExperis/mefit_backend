using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace mefit_backend.Migrations
{
    /// <inheritdoc />
    public partial class newDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WorkoutFitnessProgram",
                keyColumns: new[] { "FitnessProgramId", "WorkoutId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ImageLink", "Name", "TargetMuscleGroup", "VideoLink" },
                values: new object[] { "Beginning from the prone position. Then raise and lower your body using your arms", "https://www.fitnesseducation.edu.au/wp-content/uploads/2017/03/Pushups.jpg", "Push-ups", "pectoral muscles, triceps, and anterior deltoids", "https://www.youtube.com/watch?v=IODxDxX7oi4" });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Description", "ImageLink", "Name", "TargetMuscleGroup", "VideoLink" },
                values: new object[,]
                {
                    { 2, "It begins with lying with the back on the floor, and then elevating both the upper and lower vertebrae from the floor until everything superior to the buttocks is not touching the ground.", "https://media1.popsugar-assets.com/files/thumbor/H-fK4_7_zgVsPw4eSV584Jm5aN4/fit-in/2048xorig/filters:format_auto-!!-:strip_icc-!!-/2017/08/30/908/n/1922729/6405c6aa84236a1b_Core-Full-Sit-Ups/i/Sit-Ups.jpg", "sit-ups", "abdominal muscles", "https://www.youtube.com/watch?v=jDwoBqPH0jk" },
                    { 3, "The pull-up is a closed-chain movement where the body is suspended by the hands, gripping a bar or other implement at a distance typically wider than shoulder-width, and pulled up.", "https://www.gymlivet.com/wp-content/uploads/2015/08/pullups-gymlivet.jpg", "Pull-ups", " latissimus dorsi, trapezius, and biceps brachii.", "https://www.youtube.com/watch?v=eGo4IYlbE5g" },
                    { 4, "A squat is a strength exercise in which the trainee lowers their hips from a standing position and then stands back up. During the descent, the hip and knee joints flex while the ankle joint dorsiflexes; conversely the hip and knee joints extend and the ankle joint plantarflexes when standing up.", "https://images.bonnier.cloud/files/ifo/production/20221017085114/Squats2.jpg", "Squats", "the quadriceps femoris, the adductor magnus, and the gluteus maximus.", "https://www.youtube.com/watch?v=YaXPRqUwItQ" },
                    { 5, "The clean and jerk is a composite of two weightlifting movements, most often performed with a barbell: the clean and the jerk.", "https://i.ytimg.com/vi/PjY1rH4_MOA/maxresdefault.jpg", "Clean and Jerk", "Whole body", "https://www.youtube.com/watch?v=PjY1rH4_MOA" },
                    { 6, "The deadlift is a weight training exercise in which a loaded barbell or bar is lifted off the ground to the level of the hips, torso perpendicular to the floor, before being placed back on the ground. It is one of the three powerlifting exercises, along with the squat and bench press.", "https://i.ytimg.com/vi/1ZXobu7JvvE/maxresdefault.jpg", "Deadlift", "the gluteus maximus and gluteus minimus", "https://www.youtube.com/watch?v=1ZXobu7JvvE" },
                    { 7, " A weight training exercise where the trainee presses a weight upwards while lying on a weight training bench.", "https://www.inspireusafoundation.org/wp-content/uploads/2022/06/barbell-bench-press-benefits-1024x576.jpg", "Bench press", "the pectoralis major, the anterior deltoids, and the triceps", "https://www.youtube.com/watch?v=rT7DgCr-3pg" }
                });

            migrationBuilder.UpdateData(
                table: "FitnessPrograms",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Arm Program");

            migrationBuilder.InsertData(
                table: "FitnessPrograms",
                columns: new[] { "Id", "Category", "Name" },
                values: new object[,]
                {
                    { 2, "Lower body", "Legs Program" },
                    { 3, "Upper body", "Chest Program" },
                    { 4, "Upper body", "Back Program" }
                });

            migrationBuilder.UpdateData(
                table: "Goals",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Achieved", "title" },
                values: new object[] { true, "Goal 1" });

            migrationBuilder.UpdateData(
                table: "Impairments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Having problems with exercises involving the arms", "Arms Impairments" });

            migrationBuilder.InsertData(
                table: "Impairments",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 2, "Having problems with exercises involving the legs", "Legs Impairments" },
                    { 3, "Having problems with exercises involving the back", "Back Impairments" }
                });

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 1,
                column: "keycloakId",
                value: "5289cc70-cc80-42ee-9875-f4f685b75f5b");

            migrationBuilder.UpdateData(
                table: "WorkoutExercises",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExerciseId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Power Lift");

            migrationBuilder.InsertData(
                table: "Workouts",
                columns: new[] { "Id", "Complete", "Name", "Type" },
                values: new object[] { 2, false, "Chest Day", "Hardcore" });

            migrationBuilder.InsertData(
                table: "ImpairmentExercise",
                columns: new[] { "ExerciseId", "ImpairmentId" },
                values: new object[,]
                {
                    { 1, 3 },
                    { 2, 3 },
                    { 3, 1 },
                    { 3, 3 },
                    { 4, 2 },
                    { 4, 3 },
                    { 5, 1 },
                    { 5, 2 },
                    { 5, 3 },
                    { 6, 1 },
                    { 6, 2 },
                    { 6, 3 },
                    { 7, 1 }
                });

            migrationBuilder.InsertData(
                table: "WorkoutExercises",
                columns: new[] { "Id", "ExerciseId", "Repetition", "Set", "WorkoutId" },
                values: new object[,]
                {
                    { 2, 6, 3, 5, 1 },
                    { 3, 7, 3, 5, 1 },
                    { 4, 1, 3, 5, 2 },
                    { 5, 7, 3, 5, 2 }
                });

            migrationBuilder.InsertData(
                table: "WorkoutFitnessProgram",
                columns: new[] { "FitnessProgramId", "WorkoutId" },
                values: new object[,]
                {
                    { 3, 1 },
                    { 3, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FitnessPrograms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FitnessPrograms",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ImpairmentExercise",
                keyColumns: new[] { "ExerciseId", "ImpairmentId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "ImpairmentExercise",
                keyColumns: new[] { "ExerciseId", "ImpairmentId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "ImpairmentExercise",
                keyColumns: new[] { "ExerciseId", "ImpairmentId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "ImpairmentExercise",
                keyColumns: new[] { "ExerciseId", "ImpairmentId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "ImpairmentExercise",
                keyColumns: new[] { "ExerciseId", "ImpairmentId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "ImpairmentExercise",
                keyColumns: new[] { "ExerciseId", "ImpairmentId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "ImpairmentExercise",
                keyColumns: new[] { "ExerciseId", "ImpairmentId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "ImpairmentExercise",
                keyColumns: new[] { "ExerciseId", "ImpairmentId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "ImpairmentExercise",
                keyColumns: new[] { "ExerciseId", "ImpairmentId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "ImpairmentExercise",
                keyColumns: new[] { "ExerciseId", "ImpairmentId" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "ImpairmentExercise",
                keyColumns: new[] { "ExerciseId", "ImpairmentId" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "ImpairmentExercise",
                keyColumns: new[] { "ExerciseId", "ImpairmentId" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "ImpairmentExercise",
                keyColumns: new[] { "ExerciseId", "ImpairmentId" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "WorkoutExercises",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "WorkoutExercises",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "WorkoutExercises",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "WorkoutExercises",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "WorkoutFitnessProgram",
                keyColumns: new[] { "FitnessProgramId", "WorkoutId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "WorkoutFitnessProgram",
                keyColumns: new[] { "FitnessProgramId", "WorkoutId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "FitnessPrograms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Impairments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Impairments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ImageLink", "Name", "TargetMuscleGroup", "VideoLink" },
                values: new object[] { "Push up with arms", "some link", "Pushup", "Biceps", "some link" });

            migrationBuilder.UpdateData(
                table: "FitnessPrograms",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Program 1");

            migrationBuilder.UpdateData(
                table: "Goals",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Achieved", "title" },
                values: new object[] { false, "Goal title" });

            migrationBuilder.UpdateData(
                table: "Impairments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Cannot use legs", "I have no legs" });

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 1,
                column: "keycloakId",
                value: "1");

            migrationBuilder.UpdateData(
                table: "WorkoutExercises",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExerciseId",
                value: 1);

            migrationBuilder.InsertData(
                table: "WorkoutFitnessProgram",
                columns: new[] { "FitnessProgramId", "WorkoutId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Power Hour");
        }
    }
}
