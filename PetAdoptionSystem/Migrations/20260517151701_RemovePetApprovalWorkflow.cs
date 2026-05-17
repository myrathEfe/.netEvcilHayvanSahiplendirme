using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetAdoptionSystem.Migrations
{
    /// <inheritdoc />
    public partial class RemovePetApprovalWorkflow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
