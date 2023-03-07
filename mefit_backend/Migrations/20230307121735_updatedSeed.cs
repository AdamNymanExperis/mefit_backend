using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mefit_backend.Migrations
{
    /// <inheritdoc />
    public partial class updatedSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkoutExercise",
                table: "WorkoutExercise");

            migrationBuilder.DeleteData(
                table: "WorkoutExercise",
                keyColumns: new[] { "ExerciseId", "WorkoutId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "WorkoutExercise",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Repetition",
                table: "WorkoutExercise",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Set",
                table: "WorkoutExercise",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkoutExercise",
                table: "WorkoutExercise",
                column: "Id");

            migrationBuilder.InsertData(
                table: "WorkoutExercise",
                columns: new[] { "Id", "ExerciseId", "Repetition", "Set", "WorkoutId" },
                values: new object[] { 1, 1, 3, 5, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutExercise_ExerciseId",
                table: "WorkoutExercise",
                column: "ExerciseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkoutExercise",
                table: "WorkoutExercise");

            migrationBuilder.DropIndex(
                name: "IX_WorkoutExercise_ExerciseId",
                table: "WorkoutExercise");

            migrationBuilder.DeleteData(
                table: "WorkoutExercise",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Id",
                table: "WorkoutExercise");

            migrationBuilder.DropColumn(
                name: "Repetition",
                table: "WorkoutExercise");

            migrationBuilder.DropColumn(
                name: "Set",
                table: "WorkoutExercise");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkoutExercise",
                table: "WorkoutExercise",
                columns: new[] { "ExerciseId", "WorkoutId" });

            migrationBuilder.InsertData(
                table: "WorkoutExercise",
                columns: new[] { "ExerciseId", "WorkoutId" },
                values: new object[] { 1, 1 });
        }
    }
}
