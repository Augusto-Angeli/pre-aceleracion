using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aceleracion.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "disney");

            migrationBuilder.CreateTable(
                name: "Characters",
                schema: "disney",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    History = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.CharacterId);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                schema: "disney",
                columns: table => new
                {
                    GenreID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreID);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                schema: "disney",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Qualification = table.Column<int>(type: "int", nullable: false),
                    GenreID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieId);
                    table.ForeignKey(
                        name: "FK_Movies_Genres_GenreID",
                        column: x => x.GenreID,
                        principalSchema: "disney",
                        principalTable: "Genres",
                        principalColumn: "GenreID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterMovie",
                schema: "disney",
                columns: table => new
                {
                    CharactersCharacterId = table.Column<int>(type: "int", nullable: false),
                    MoviesMovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterMovie", x => new { x.CharactersCharacterId, x.MoviesMovieId });
                    table.ForeignKey(
                        name: "FK_CharacterMovie_Characters_CharactersCharacterId",
                        column: x => x.CharactersCharacterId,
                        principalSchema: "disney",
                        principalTable: "Characters",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterMovie_Movies_MoviesMovieId",
                        column: x => x.MoviesMovieId,
                        principalSchema: "disney",
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "disney",
                table: "Characters",
                columns: new[] { "CharacterId", "Age", "History", "Image", "Name", "Weight" },
                values: new object[] { 5, 20, "A toy", "Buzz Image", "Buzz", 3 });

            migrationBuilder.InsertData(
                schema: "disney",
                table: "Characters",
                columns: new[] { "CharacterId", "Age", "History", "Image", "Name", "Weight" },
                values: new object[] { 6, 25, "A Mouse", "Mickey Image", "Mickey", 4 });

            migrationBuilder.InsertData(
                schema: "disney",
                table: "Genres",
                columns: new[] { "GenreID", "Image", "Name" },
                values: new object[] { 5, "Action Image", "Action" });

            migrationBuilder.InsertData(
                schema: "disney",
                table: "Movies",
                columns: new[] { "MovieId", "CreationDate", "GenreID", "Image", "Qualification", "Title" },
                values: new object[] { 5, new DateTime(2021, 7, 14, 0, 0, 0, 0, DateTimeKind.Local), 5, "The Lion King Image", 2, "The Lion King" });

            migrationBuilder.InsertData(
                schema: "disney",
                table: "Movies",
                columns: new[] { "MovieId", "CreationDate", "GenreID", "Image", "Qualification", "Title" },
                values: new object[] { 6, new DateTime(2021, 7, 14, 0, 0, 0, 0, DateTimeKind.Local), 5, "Cars Image", 5, "Cars" });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterMovie_MoviesMovieId",
                schema: "disney",
                table: "CharacterMovie",
                column: "MoviesMovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GenreID",
                schema: "disney",
                table: "Movies",
                column: "GenreID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterMovie",
                schema: "disney");

            migrationBuilder.DropTable(
                name: "Characters",
                schema: "disney");

            migrationBuilder.DropTable(
                name: "Movies",
                schema: "disney");

            migrationBuilder.DropTable(
                name: "Genres",
                schema: "disney");
        }
    }
}
