using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetAdoptionSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddPetModerationAndCareFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApprovalStatus",
                table: "Pets",
                type: "int",
                nullable: false,
                defaultValue: 2);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Pets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DisabilityDescription",
                table: "Pets",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DisabilityStatus",
                table: "Pets",
                type: "int",
                nullable: false,
                defaultValue: 3);

            migrationBuilder.AddColumn<int>(
                name: "SterilizationStatus",
                table: "Pets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pets_CreatedByUserId",
                table: "Pets",
                column: "CreatedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Users_CreatedByUserId",
                table: "Pets",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Users_CreatedByUserId",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_CreatedByUserId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "ApprovalStatus",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "DisabilityDescription",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "DisabilityStatus",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "SterilizationStatus",
                table: "Pets");
        }
    }
}
