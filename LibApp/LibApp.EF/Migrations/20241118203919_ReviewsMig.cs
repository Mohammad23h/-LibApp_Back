using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibApp.EF.Migrations
{
    /// <inheritdoc />
    public partial class ReviewsMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthorReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    AuthorEv = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuthorReviews_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorReviews_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    BookEv = table.Column<int>(type: "int", nullable: false),
                    ReadingId = table.Column<int>(type: "int", nullable: false),
                    ReadingEv = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookReviews_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookReviews_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuthorComment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AtReviewId = table.Column<int>(type: "int", nullable: false),
                    AuthorReviewId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuthorComment_AuthorReviews_AuthorReviewId",
                        column: x => x.AuthorReviewId,
                        principalTable: "AuthorReviews",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BookComment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BkReviewId = table.Column<int>(type: "int", nullable: false),
                    BookReviewId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookComment_BookReviews_BookReviewId",
                        column: x => x.BookReviewId,
                        principalTable: "BookReviews",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorComment_AuthorReviewId",
                table: "AuthorComment",
                column: "AuthorReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorReviews_AuthorId",
                table: "AuthorReviews",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorReviews_UserId",
                table: "AuthorReviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BookComment_BookReviewId",
                table: "BookComment",
                column: "BookReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_BookReviews_BookId",
                table: "BookReviews",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookReviews_UserId",
                table: "BookReviews",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorComment");

            migrationBuilder.DropTable(
                name: "BookComment");

            migrationBuilder.DropTable(
                name: "AuthorReviews");

            migrationBuilder.DropTable(
                name: "BookReviews");
        }
    }
}
