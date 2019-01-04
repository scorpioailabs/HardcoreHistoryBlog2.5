using Microsoft.EntityFrameworkCore.Migrations;

namespace HardcoreHistoryBlog.Migrations
{
    public partial class assignroles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserRolesViewModel",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Rolename = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRolesViewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRolesViewModel_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRolesViewModel_RoleId",
                table: "UserRolesViewModel",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRolesViewModel");
        }
    }
}
