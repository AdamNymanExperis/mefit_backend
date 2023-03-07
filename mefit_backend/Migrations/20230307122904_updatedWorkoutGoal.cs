using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mefit_backend.Migrations
{
    /// <inheritdoc />
    public partial class updatedWorkoutGoal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutGoal_Goals_GoalId",
                table: "WorkoutGoal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkoutGoal",
                table: "WorkoutGoal");

            migrationBuilder.DeleteData(
                table: "WorkoutGoal",
                keyColumns: new[] { "GoalId", "WorkoutId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "WorkoutGoal",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "WorkoutGoal",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkoutGoal",
                table: "WorkoutGoal",
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

            migrationBuilder.InsertData(
                table: "WorkoutGoal",
                columns: new[] { "Id", "EndDate", "GoalId", "WorkoutId" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutGoal_WorkoutId",
                table: "WorkoutGoal",
                column: "WorkoutId");

            migrationBuilder.CreateIndex(
                name: "IX_GoalWorkout_WorkoutsId",
                table: "GoalWorkout",
                column: "WorkoutsId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutGoal_Exercises_GoalId",
                table: "WorkoutGoal",
                column: "GoalId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutGoal_Exercises_GoalId",
                table: "WorkoutGoal");

            migrationBuilder.DropTable(
                name: "GoalWorkout");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkoutGoal",
                table: "WorkoutGoal");

            migrationBuilder.DropIndex(
                name: "IX_WorkoutGoal_WorkoutId",
                table: "WorkoutGoal");

            migrationBuilder.DeleteData(
                table: "WorkoutGoal",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Id",
                table: "WorkoutGoal");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "WorkoutGoal");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkoutGoal",
                table: "WorkoutGoal",
                columns: new[] { "WorkoutId", "GoalId" });

            migrationBuilder.InsertData(
                table: "WorkoutGoal",
                columns: new[] { "GoalId", "WorkoutId" },
                values: new object[] { 1, 1 });

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutGoal_Goals_GoalId",
                table: "WorkoutGoal",
                column: "GoalId",
                principalTable: "Goals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
