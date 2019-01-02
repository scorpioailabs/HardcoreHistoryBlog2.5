using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HardcoreHistoryBlog.Migrations
{
    public partial class usercomms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnalyticsViewModel");
            migrationBuilder.CreateTable(
    name: "MainComments",
    columns: table => new
    {
        Id = table.Column<int>(nullable: false)
            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        Message = table.Column<string>(nullable: true),
        Created = table.Column<DateTime>(nullable: false),
        Edited = table.Column<DateTime>(nullable: false),
        By = table.Column<string>(nullable: true),
        UserId = table.Column<string>(nullable: true),
        PostId = table.Column<int>(nullable: true)
    },
    constraints: table =>
    {
        table.PrimaryKey("PK_MainComments", x => x.Id);
        table.ForeignKey(
            name: "FK_MainComments_Posts_PostId",
            column: x => x.PostId,
            principalTable: "Posts",
            principalColumn: "Id",
            onDelete: ReferentialAction.Restrict);
        table.ForeignKey(
            name: "FK_MainComments_AspNetUsers_UserId",
            column: x => x.UserId,
            principalTable: "AspNetUsers",
            principalColumn: "Id",
            onDelete: ReferentialAction.Restrict);
    });

            migrationBuilder.CreateTable(
                name: "SubComments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Message = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Edited = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    By = table.Column<string>(nullable: true),
                    MainCommentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubComments_MainComments_MainCommentId",
                        column: x => x.MainCommentId,
                        principalTable: "MainComments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubComments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubComments_MainCommentId",
                table: "SubComments",
                column: "MainCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_SubComments_UserId",
                table: "SubComments",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubComments");

            migrationBuilder.CreateTable(
                name: "AnalyticsViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NumberOfComments = table.Column<int>(nullable: false),
                    NumberOfUsers = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalyticsViewModel", x => x.Id);
                });
        }
    }
}
