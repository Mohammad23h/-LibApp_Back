using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibApp.EF.Migrations
{
    /// <inheritdoc />
    public partial class FinalforTablesMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorComment_AuthorReviews_AuthorReviewId",
                table: "AuthorComment");

            migrationBuilder.DropForeignKey(
                name: "FK_Book_Author_Authors_AuthorId",
                table: "Book_Author");

            migrationBuilder.DropForeignKey(
                name: "FK_Book_Author_Books_BookId",
                table: "Book_Author");

            migrationBuilder.DropForeignKey(
                name: "FK_BookComment_BookReviews_BookReviewId",
                table: "BookComment");

            migrationBuilder.DropForeignKey(
                name: "FK_Lestening_AspNetUsers_LestenerId",
                table: "Lestening");

            migrationBuilder.DropForeignKey(
                name: "FK_Lestening_Readings_ReadingId",
                table: "Lestening");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lestening",
                table: "Lestening");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookComment",
                table: "BookComment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Book_Author",
                table: "Book_Author");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuthorComment",
                table: "AuthorComment");

            migrationBuilder.RenameTable(
                name: "Lestening",
                newName: "Lestenings");

            migrationBuilder.RenameTable(
                name: "BookComment",
                newName: "BookComments");

            migrationBuilder.RenameTable(
                name: "Book_Author",
                newName: "Books_Authors");

            migrationBuilder.RenameTable(
                name: "AuthorComment",
                newName: "AuthorComments");

            migrationBuilder.RenameIndex(
                name: "IX_Lestening_ReadingId",
                table: "Lestenings",
                newName: "IX_Lestenings_ReadingId");

            migrationBuilder.RenameIndex(
                name: "IX_Lestening_LestenerId",
                table: "Lestenings",
                newName: "IX_Lestenings_LestenerId");

            migrationBuilder.RenameIndex(
                name: "IX_BookComment_BookReviewId",
                table: "BookComments",
                newName: "IX_BookComments_BookReviewId");

            migrationBuilder.RenameIndex(
                name: "IX_Book_Author_BookId",
                table: "Books_Authors",
                newName: "IX_Books_Authors_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_Book_Author_AuthorId",
                table: "Books_Authors",
                newName: "IX_Books_Authors_AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_AuthorComment_AuthorReviewId",
                table: "AuthorComments",
                newName: "IX_AuthorComments_AuthorReviewId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lestenings",
                table: "Lestenings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookComments",
                table: "BookComments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books_Authors",
                table: "Books_Authors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuthorComments",
                table: "AuthorComments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorComments_AuthorReviews_AuthorReviewId",
                table: "AuthorComments",
                column: "AuthorReviewId",
                principalTable: "AuthorReviews",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookComments_BookReviews_BookReviewId",
                table: "BookComments",
                column: "BookReviewId",
                principalTable: "BookReviews",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_Authors_AuthorId",
                table: "Books_Authors",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_Books_BookId",
                table: "Books_Authors",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lestenings_AspNetUsers_LestenerId",
                table: "Lestenings",
                column: "LestenerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lestenings_Readings_ReadingId",
                table: "Lestenings",
                column: "ReadingId",
                principalTable: "Readings",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorComments_AuthorReviews_AuthorReviewId",
                table: "AuthorComments");

            migrationBuilder.DropForeignKey(
                name: "FK_BookComments_BookReviews_BookReviewId",
                table: "BookComments");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_Authors_AuthorId",
                table: "Books_Authors");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_Books_BookId",
                table: "Books_Authors");

            migrationBuilder.DropForeignKey(
                name: "FK_Lestenings_AspNetUsers_LestenerId",
                table: "Lestenings");

            migrationBuilder.DropForeignKey(
                name: "FK_Lestenings_Readings_ReadingId",
                table: "Lestenings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lestenings",
                table: "Lestenings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Books_Authors",
                table: "Books_Authors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookComments",
                table: "BookComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuthorComments",
                table: "AuthorComments");

            migrationBuilder.RenameTable(
                name: "Lestenings",
                newName: "Lestening");

            migrationBuilder.RenameTable(
                name: "Books_Authors",
                newName: "Book_Author");

            migrationBuilder.RenameTable(
                name: "BookComments",
                newName: "BookComment");

            migrationBuilder.RenameTable(
                name: "AuthorComments",
                newName: "AuthorComment");

            migrationBuilder.RenameIndex(
                name: "IX_Lestenings_ReadingId",
                table: "Lestening",
                newName: "IX_Lestening_ReadingId");

            migrationBuilder.RenameIndex(
                name: "IX_Lestenings_LestenerId",
                table: "Lestening",
                newName: "IX_Lestening_LestenerId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_Authors_BookId",
                table: "Book_Author",
                newName: "IX_Book_Author_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_Authors_AuthorId",
                table: "Book_Author",
                newName: "IX_Book_Author_AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_BookComments_BookReviewId",
                table: "BookComment",
                newName: "IX_BookComment_BookReviewId");

            migrationBuilder.RenameIndex(
                name: "IX_AuthorComments_AuthorReviewId",
                table: "AuthorComment",
                newName: "IX_AuthorComment_AuthorReviewId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lestening",
                table: "Lestening",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Book_Author",
                table: "Book_Author",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookComment",
                table: "BookComment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuthorComment",
                table: "AuthorComment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorComment_AuthorReviews_AuthorReviewId",
                table: "AuthorComment",
                column: "AuthorReviewId",
                principalTable: "AuthorReviews",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Author_Authors_AuthorId",
                table: "Book_Author",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Author_Books_BookId",
                table: "Book_Author",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookComment_BookReviews_BookReviewId",
                table: "BookComment",
                column: "BookReviewId",
                principalTable: "BookReviews",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lestening_AspNetUsers_LestenerId",
                table: "Lestening",
                column: "LestenerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lestening_Readings_ReadingId",
                table: "Lestening",
                column: "ReadingId",
                principalTable: "Readings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
