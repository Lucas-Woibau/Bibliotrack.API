using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bibliotrack.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRegistrationCodeMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RegistrationNumber",
                table: "Books",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegistrationNumber",
                table: "Books");
        }
    }
}
