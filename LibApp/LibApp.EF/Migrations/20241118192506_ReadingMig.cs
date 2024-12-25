using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibApp.EF.Migrations
{
    /// <inheritdoc />
    public partial class ReadingMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Readings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    ReaderId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Readings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Readings_AspNetUsers_ReaderId",
                        column: x => x.ReaderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Readings_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lestening",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LestenerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReadingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lestening", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lestening_AspNetUsers_LestenerId",
                        column: x => x.LestenerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lestening_Readings_ReadingId",
                        column: x => x.ReadingId,
                        principalTable: "Readings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);// I have edit this from Casade to No Action
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lestening_LestenerId",
                table: "Lestening",
                column: "LestenerId");

            migrationBuilder.CreateIndex(
                name: "IX_Lestening_ReadingId",
                table: "Lestening",
                column: "ReadingId");

            migrationBuilder.CreateIndex(
                name: "IX_Readings_BookId",
                table: "Readings",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Readings_ReaderId",
                table: "Readings",
                column: "ReaderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lestening");

            migrationBuilder.DropTable(
                name: "Readings");
        }
    }
}
