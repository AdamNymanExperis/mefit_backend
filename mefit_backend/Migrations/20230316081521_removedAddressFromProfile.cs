using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mefit_backend.Migrations
{
    /// <inheritdoc />
    public partial class removedAddressFromProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Addresses_AddressId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_AddressId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Profiles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Profiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 1,
                column: "AddressId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_AddressId",
                table: "Profiles",
                column: "AddressId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Addresses_AddressId",
                table: "Profiles",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
