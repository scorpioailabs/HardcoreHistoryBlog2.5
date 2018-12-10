using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HardcoreHistoryBlog.Data.Migrations
{
    public partial class blogmodels2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_AspNetUsers_UserId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Bloggers_ContributerBloggerId",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Posts_ContributerBloggerId",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ContributerBloggerId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Meta",
                table: "Posts");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Members");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_UserId",
                table: "Members",
                newName: "IX_Members_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Members",
                table: "Members",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ContributorBloggerId",
                table: "Posts",
                column: "ContributorBloggerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_AspNetUsers_UserId",
                table: "Members",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Bloggers_ContributorBloggerId",
                table: "Posts",
                column: "ContributorBloggerId",
                principalTable: "Bloggers",
                principalColumn: "BloggerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_AspNetUsers_UserId",
                table: "Members");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Bloggers_ContributorBloggerId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_ContributorBloggerId",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Members",
                table: "Members");

            migrationBuilder.RenameTable(
                name: "Members",
                newName: "Customers");

            migrationBuilder.RenameIndex(
                name: "IX_Members_UserId",
                table: "Customers",
                newName: "IX_Customers_UserId");

            migrationBuilder.AddColumn<int>(
                name: "ContributerBloggerId",
                table: "Posts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Meta",
                table: "Posts",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ContributerBloggerId",
                table: "Posts",
                column: "ContributerBloggerId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_UserId",
                table: "Clients",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_AspNetUsers_UserId",
                table: "Customers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Bloggers_ContributerBloggerId",
                table: "Posts",
                column: "ContributerBloggerId",
                principalTable: "Bloggers",
                principalColumn: "BloggerId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
