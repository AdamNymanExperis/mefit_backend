using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mefit_backend.Migrations
{
    /// <inheritdoc />
    public partial class updatedConnectionTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutExercise_Exercises_ExerciseId",
                table: "WorkoutExercise");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutExercise_Workouts_WorkoutId",
                table: "WorkoutExercise");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutGoal_Exercises_GoalId",
                table: "WorkoutGoal");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutGoal_Workouts_WorkoutId",
                table: "WorkoutGoal");

            migrationBuilder.DropTable(
                name: "GoalWorkout");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkoutGoal",
                table: "WorkoutGoal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkoutExercise",
                table: "WorkoutExercise");

            migrationBuilder.RenameTable(
                name: "WorkoutGoal",
                newName: "WorkoutGoals");

            migrationBuilder.RenameTable(
                name: "WorkoutExercise",
                newName: "WorkoutExercises");

            migrationBuilder.RenameIndex(
                name: "IX_WorkoutGoal_WorkoutId",
                table: "WorkoutGoals",
                newName: "IX_WorkoutGoals_WorkoutId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkoutGoal_GoalId",
                table: "WorkoutGoals",
                newName: "IX_WorkoutGoals_GoalId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkoutExercise_WorkoutId",
                table: "WorkoutExercises",
                newName: "IX_WorkoutExercises_WorkoutId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkoutExercise_ExerciseId",
                table: "WorkoutExercises",
                newName: "IX_WorkoutExercises_ExerciseId");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(320)",
                maxLength: 320,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkoutGoals",
                table: "WorkoutGoals",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkoutExercises",
                table: "WorkoutExercises",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutExercises_Exercises_ExerciseId",
                table: "WorkoutExercises",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutExercises_Workouts_WorkoutId",
                table: "WorkoutExercises",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutGoals_Goals_GoalId",
                table: "WorkoutGoals",
                column: "GoalId",
                principalTable: "Goals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutGoals_Workouts_WorkoutId",
                table: "WorkoutGoals",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutExercises_Exercises_ExerciseId",
                table: "WorkoutExercises");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutExercises_Workouts_WorkoutId",
                table: "WorkoutExercises");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutGoals_Goals_GoalId",
                table: "WorkoutGoals");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutGoals_Workouts_WorkoutId",
                table: "WorkoutGoals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkoutGoals",
                table: "WorkoutGoals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkoutExercises",
                table: "WorkoutExercises");

            migrationBuilder.RenameTable(
                name: "WorkoutGoals",
                newName: "WorkoutGoal");

            migrationBuilder.RenameTable(
                name: "WorkoutExercises",
                newName: "WorkoutExercise");

            migrationBuilder.RenameIndex(
                name: "IX_WorkoutGoals_WorkoutId",
                table: "WorkoutGoal",
                newName: "IX_WorkoutGoal_WorkoutId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkoutGoals_GoalId",
                table: "WorkoutGoal",
                newName: "IX_WorkoutGoal_GoalId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkoutExercises_WorkoutId",
                table: "WorkoutExercise",
                newName: "IX_WorkoutExercise_WorkoutId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkoutExercises_ExerciseId",
                table: "WorkoutExercise",
                newName: "IX_WorkoutExercise_ExerciseId");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(320)",
                oldMaxLength: 320);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkoutGoal",
                table: "WorkoutGoal",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkoutExercise",
                table: "WorkoutExercise",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "GoalWorkout",
                columns: table => new
                {
                    GoalsId = table.Column<int>(type: "int", nullable: false),
                    WorkoutsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoalWorkout", x => new { x.GoalsId, x.WorkoutsId });
                    table.ForeignKey(
                        name: "FK_GoalWorkout_Goals_GoalsId",
                        column: x => x.GoalsId,
                        principalTable: "Goals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GoalWorkout_Workouts_WorkoutsId",
                        column: x => x.WorkoutsId,
                        principalTable: "Workouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GoalWorkout_WorkoutsId",
                table: "GoalWorkout",
                column: "WorkoutsId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutExercise_Exercises_ExerciseId",
                table: "WorkoutExercise",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutExercise_Workouts_WorkoutId",
                table: "WorkoutExercise",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutGoal_Exercises_GoalId",
                table: "WorkoutGoal",
                column: "GoalId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutGoal_Workouts_WorkoutId",
                table: "WorkoutGoal",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
