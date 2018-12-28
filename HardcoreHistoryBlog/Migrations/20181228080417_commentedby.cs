using Microsoft.EntityFrameworkCore.Migrations;

namespace HardcoreHistoryBlog.Migrations
{
    public partial class commentedby : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "By",
                table: "SubComments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "By",
                table: "MainComments",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UsersViewModel",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    Username = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(maxLength: 100, nullable: false),
                    ConfirmPassword = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersViewModel", x => x.UserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersViewModel");

            migrationBuilder.DropColumn(
                name: "By",
                table: "SubComments");

            migrationBuilder.DropColumn(
                name: "By",
                table: "MainComments");
        }
    }
}
