using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sem2.Migrations
{
    /// <inheritdoc />
    public partial class Crearingtheoverallentities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModuleName",
                table: "Modules",
                newName: "Title");

            migrationBuilder.AddColumn<int>(
                name: "Credit",
                table: "Modules",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Credit",
                table: "Modules");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Modules",
                newName: "ModuleName");
        }
    }
}
