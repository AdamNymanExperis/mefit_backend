using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mefit_backend.Migrations
{
    /// <inheritdoc />
    public partial class updatedGoalAndConnectionTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FitnessProgramGoal");

            migrationBuilder.CreateTable(
                name: "FitnessProgramGoals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GoalId = table.Column<int>(type: "int", nullable: false),
                    FitnessProgramId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FitnessProgramGoals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FitnessProgramGoals_FitnessPrograms_FitnessProgramId",
                        column: x => x.FitnessProgramId,
                        principalTable: "FitnessPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FitnessProgramGoals_Goals_GoalId",
                        column: x => x.GoalId,
                        principalTable: "Goals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FitnessProgramGoals",
                columns: new[] { "Id", "EndDate", "FitnessProgramId", "GoalId" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_FitnessProgramGoals_FitnessProgramId",
                table: "FitnessProgramGoals",
                column: "FitnessProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_FitnessProgramGoals_GoalId",
                table: "FitnessProgramGoals",
                column: "GoalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FitnessProgramGoals");

            migrationBuilder.CreateTable(
                name: "FitnessProgramGoal",
                columns: table => new
                {
                    FitnessProgramId = table.Column<int>(type: "int", nullable: false),
                    GoalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FitnessProgramGoal", x => new { x.FitnessProgramId, x.GoalId });
                    table.ForeignKey(
                        name: "FK_FitnessProgramGoal_FitnessPrograms_FitnessProgramId",
                        column: x => x.FitnessProgramId,
                        principalTable: "FitnessPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FitnessProgramGoal_Goals_GoalId",
                        column: x => x.GoalId,
                        principalTable: "Goals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FitnessProgramGoal",
                columns: new[] { "FitnessProgramId", "GoalId" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_FitnessProgramGoal_GoalId",
                table: "FitnessProgramGoal",
                column: "GoalId");
        }
    }
}
