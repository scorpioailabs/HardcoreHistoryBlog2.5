using Microsoft.EntityFrameworkCore.Migrations;

namespace HardcoreHistoryBlog.Migrations
{
    public partial class commentedbyforreal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_AuthorId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetRoles_RoleId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_MainComments_AspNetUsers_ClientId",
                table: "MainComments");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_ClientId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_SubComments_AspNetUsers_ClientId",
                table: "SubComments");

            migrationBuilder.DropIndex(
                name: "IX_SubComments_ClientId",
                table: "SubComments");

            migrationBuilder.DropIndex(
                name: "IX_Posts_ClientId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_MainComments_ClientId",
                table: "MainComments");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AuthorId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_RoleId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "SubComments");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "MainComments");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "SubComments",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "MainComments",
                newName: "UserId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "SubComments",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "MainComments",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubComments_UserId",
                table: "SubComments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MainComments_UserId",
                table: "MainComments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MainComments_AspNetUsers_UserId",
                table: "MainComments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubComments_AspNetUsers_UserId",
                table: "SubComments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MainComments_AspNetUsers_UserId",
                table: "MainComments");

            migrationBuilder.DropForeignKey(
                name: "FK_SubComments_AspNetUsers_UserId",
                table: "SubComments");

            migrationBuilder.DropIndex(
                name: "IX_SubComments_UserId",
                table: "SubComments");

            migrationBuilder.DropIndex(
                name: "IX_MainComments_UserId",
                table: "MainComments");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "SubComments",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "MainComments",
                newName: "CustomerId");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "SubComments",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClientId",
                table: "SubComments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClientId",
                table: "Posts",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "MainComments",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClientId",
                table: "MainComments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AuthorId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoleId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubComments_ClientId",
                table: "SubComments",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ClientId",
                table: "Posts",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_MainComments_ClientId",
                table: "MainComments",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AuthorId",
                table: "AspNetUsers",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RoleId",
                table: "AspNetUsers",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_AuthorId",
                table: "AspNetUsers",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetRoles_RoleId",
                table: "AspNetUsers",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MainComments_AspNetUsers_ClientId",
                table: "MainComments",
                column: "ClientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_ClientId",
                table: "Posts",
                column: "ClientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubComments_AspNetUsers_ClientId",
                table: "SubComments",
                column: "ClientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
