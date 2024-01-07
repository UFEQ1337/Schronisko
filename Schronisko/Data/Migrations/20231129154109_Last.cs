using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Schronisko.Data.Migrations
{
    /// <inheritdoc />
    public partial class Last : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Shelter",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shelter_UserId",
                table: "Shelter",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shelter_AspNetUsers_UserId",
                table: "Shelter",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shelter_AspNetUsers_UserId",
                table: "Shelter");

            migrationBuilder.DropIndex(
                name: "IX_Shelter_UserId",
                table: "Shelter");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Shelter");
        }
    }
}
