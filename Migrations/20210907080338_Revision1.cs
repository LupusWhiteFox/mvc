using Microsoft.EntityFrameworkCore.Migrations;

namespace aspnet.Migrations
{
    public partial class Revision1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "Books",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "ISBN",
                table: "Books",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ISBN",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Books",
                newName: "name");
        }
    }
}
