using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Forum",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forum", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    ImagePath = table.Column<string>(type: "TEXT", nullable: false),
                    ForumContainerId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Email);
                    table.ForeignKey(
                        name: "FK_Users_Forum_ForumContainerId",
                        column: x => x.ForumContainerId,
                        principalTable: "Forum",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Uid = table.Column<string>(type: "TEXT", nullable: false),
                    Header = table.Column<string>(type: "TEXT", nullable: false),
                    Body = table.Column<string>(type: "TEXT", nullable: false),
                    WrittenByEmail = table.Column<string>(type: "TEXT", nullable: false),
                    Image = table.Column<string>(type: "TEXT", nullable: false),
                    DateTime = table.Column<DateTime>(type: "Date", nullable: false),
                    ForumContainerId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Uid);
                    table.ForeignKey(
                        name: "FK_Posts_Forum_ForumContainerId",
                        column: x => x.ForumContainerId,
                        principalTable: "Forum",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Posts_Users_WrittenByEmail",
                        column: x => x.WrittenByEmail,
                        principalTable: "Users",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Body = table.Column<string>(type: "TEXT", nullable: false),
                    WrittenByEmail = table.Column<string>(type: "TEXT", nullable: false),
                    PostUid = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CID);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostUid",
                        column: x => x.PostUid,
                        principalTable: "Posts",
                        principalColumn: "Uid");
                    table.ForeignKey(
                        name: "FK_Comments_Users_WrittenByEmail",
                        column: x => x.WrittenByEmail,
                        principalTable: "Users",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Votes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Value = table.Column<short>(type: "INTEGER", nullable: false),
                    VoterEmail = table.Column<string>(type: "TEXT", nullable: true),
                    CommentCID = table.Column<Guid>(type: "TEXT", nullable: true),
                    PostUid = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Votes_Comments_CommentCID",
                        column: x => x.CommentCID,
                        principalTable: "Comments",
                        principalColumn: "CID");
                    table.ForeignKey(
                        name: "FK_Votes_Posts_PostUid",
                        column: x => x.PostUid,
                        principalTable: "Posts",
                        principalColumn: "Uid");
                    table.ForeignKey(
                        name: "FK_Votes_Users_VoterEmail",
                        column: x => x.VoterEmail,
                        principalTable: "Users",
                        principalColumn: "Email");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostUid",
                table: "Comments",
                column: "PostUid");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_WrittenByEmail",
                table: "Comments",
                column: "WrittenByEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ForumContainerId",
                table: "Posts",
                column: "ForumContainerId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_WrittenByEmail",
                table: "Posts",
                column: "WrittenByEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ForumContainerId",
                table: "Users",
                column: "ForumContainerId");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_CommentCID",
                table: "Votes",
                column: "CommentCID");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_PostUid",
                table: "Votes",
                column: "PostUid");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_VoterEmail",
                table: "Votes",
                column: "VoterEmail");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Votes");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Forum");
        }
    }
}
