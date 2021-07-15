using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aceleracion.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Genres_GenreID",
                schema: "disney",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "GenreID",
                schema: "disney",
                table: "Movies",
                newName: "GenreId");

            migrationBuilder.RenameIndex(
                name: "IX_Movies_GenreID",
                schema: "disney",
                table: "Movies",
                newName: "IX_Movies_GenreId");

            migrationBuilder.RenameColumn(
                name: "GenreID",
                schema: "disney",
                table: "Genres",
                newName: "GenreId");

            migrationBuilder.UpdateData(
                schema: "disney",
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 5,
                columns: new[] { "Image", "Name" },
                values: new object[] { "Romance Image", "Romance" });

            migrationBuilder.InsertData(
                schema: "disney",
                table: "Genres",
                columns: new[] { "GenreId", "Image", "Name" },
                values: new object[,]
                {
                    { 1, "Action Image", "Action" },
                    { 2, "Comedy Image", "Comedy" },
                    { 3, "Suspense Image", "Suspense" },
                    { 4, "Drama Image", "Drama" }
                });

            migrationBuilder.UpdateData(
                schema: "disney",
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 5,
                column: "CreationDate",
                value: new DateTime(2021, 7, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                schema: "disney",
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 6,
                column: "CreationDate",
                value: new DateTime(2021, 7, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Genres_GenreId",
                schema: "disney",
                table: "Movies",
                column: "GenreId",
                principalSchema: "disney",
                principalTable: "Genres",
                principalColumn: "GenreId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Genres_GenreId",
                schema: "disney",
                table: "Movies");

            migrationBuilder.DeleteData(
                schema: "disney",
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "disney",
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "disney",
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "disney",
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 4);

            migrationBuilder.RenameColumn(
                name: "GenreId",
                schema: "disney",
                table: "Movies",
                newName: "GenreID");

            migrationBuilder.RenameIndex(
                name: "IX_Movies_GenreId",
                schema: "disney",
                table: "Movies",
                newName: "IX_Movies_GenreID");

            migrationBuilder.RenameColumn(
                name: "GenreId",
                schema: "disney",
                table: "Genres",
                newName: "GenreID");

            migrationBuilder.UpdateData(
                schema: "disney",
                table: "Genres",
                keyColumn: "GenreID",
                keyValue: 5,
                columns: new[] { "Image", "Name" },
                values: new object[] { "Action Image", "Action" });

            migrationBuilder.UpdateData(
                schema: "disney",
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 5,
                column: "CreationDate",
                value: new DateTime(2021, 7, 14, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                schema: "disney",
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 6,
                column: "CreationDate",
                value: new DateTime(2021, 7, 14, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Genres_GenreID",
                schema: "disney",
                table: "Movies",
                column: "GenreID",
                principalSchema: "disney",
                principalTable: "Genres",
                principalColumn: "GenreID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
