using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppPeliculas.Migrations
{
    /// <inheritdoc />
    public partial class AddDuracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Duracion",
                table: "Peliculas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: 1,
                columns: new[] { "Duracion", "Titulo" },
                values: new object[] { 120, "Alien Covenant" });

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: 2,
                column: "Duracion",
                value: 120);

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: 3,
                column: "Duracion",
                value: 120);

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: 4,
                column: "Duracion",
                value: 120);

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: 5,
                column: "Duracion",
                value: 120);

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: 6,
                column: "Duracion",
                value: 120);

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: 7,
                column: "Duracion",
                value: 120);

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: 8,
                column: "Duracion",
                value: 120);

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: 9,
                column: "Duracion",
                value: 120);

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: 10,
                column: "Duracion",
                value: 120);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duracion",
                table: "Peliculas");

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: 1,
                column: "Titulo",
                value: "Alien Convenant");
        }
    }
}
