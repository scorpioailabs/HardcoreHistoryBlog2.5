using Microsoft.EntityFrameworkCore.Migrations;

namespace HardcoreHistoryBlog.Migrations
{
    public partial class roledescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AspNetRoles",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RoleViewModel",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleViewModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRoleViewModel",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    RoleName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    NumberOfUsers = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoleViewModel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleViewModel");

            migrationBuilder.DropTable(
                name: "UserRoleViewModel");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "AspNetRoles");
        }
    }
}
