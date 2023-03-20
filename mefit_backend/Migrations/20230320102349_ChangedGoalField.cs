using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mefit_backend.Migrations
{
    /// <inheritdoc />
    public partial class ChangedGoalField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "WorkoutGoals",
                newName: "start");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "WorkoutGoals",
                newName: "end");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Goals",
                newName: "start");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "Goals",
                newName: "end");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "FitnessProgramGoals",
                newName: "start");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "FitnessProgramGoals",
                newName: "end");

            migrationBuilder.AddColumn<string>(
                name: "title",
                table: "Goals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Goals",
                keyColumn: "Id",
                keyValue: 1,
                column: "title",
                value: "Goal title");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "title",
                table: "Goals");

            migrationBuilder.RenameColumn(
                name: "start",
                table: "WorkoutGoals",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "end",
                table: "WorkoutGoals",
                newName: "EndDate");

            migrationBuilder.RenameColumn(
                name: "start",
                table: "Goals",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "end",
                table: "Goals",
                newName: "EndDate");

            migrationBuilder.RenameColumn(
                name: "start",
                table: "FitnessProgramGoals",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "end",
                table: "FitnessProgramGoals",
                newName: "EndDate");
        }
    }
}
