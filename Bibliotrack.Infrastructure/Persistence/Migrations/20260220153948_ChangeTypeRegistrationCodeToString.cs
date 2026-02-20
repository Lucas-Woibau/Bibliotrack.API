using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bibliotrack.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTypeRegistrationCodeToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegistrationNumber",
                table: "Books");

            migrationBuilder.AddColumn<string>(
                name: "RegistrationCode",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegistrationCode",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "RegistrationNumber",
                table: "Books",
                type: "int",
                nullable: true);
        }
    }
}
