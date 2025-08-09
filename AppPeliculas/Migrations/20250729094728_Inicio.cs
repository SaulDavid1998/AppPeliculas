using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppPeliculas.Migrations
{
    /// <inheritdoc />
    public partial class Inicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estudios",
                columns: table => new
                {
                    EstudioID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EstudioNombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudios", x => x.EstudioID);
                });

            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    GeneroID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GeneroNombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.GeneroID);
                });

            migrationBuilder.CreateTable(
                name: "Peliculas",
                columns: table => new
                {
                    PeliculaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    Estreno = table.Column<int>(type: "int", nullable: false),
                    GeneroFK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EstudioFK = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peliculas", x => x.PeliculaId);
                    table.ForeignKey(
                        name: "FK_Peliculas_Estudios_EstudioFK",
                        column: x => x.EstudioFK,
                        principalTable: "Estudios",
                        principalColumn: "EstudioID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Peliculas_Generos_GeneroFK",
                        column: x => x.GeneroFK,
                        principalTable: "Generos",
                        principalColumn: "GeneroID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Estudios",
                columns: new[] { "EstudioID", "EstudioNombre" },
                values: new object[,]
                {
                    { "20Century", "20 Century" },
                    { "columbia", "Columbia Pictures" },
                    { "disney", "Disney" },
                    { "paramount", "Paramount Pictures" }
                });

            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "GeneroID", "GeneroNombre" },
                values: new object[,]
                {
                    { "accion", "Accion" },
                    { "comedia", "Comedia" },
                    { "terror", "Terror" }
                });

            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "PeliculaId", "Descripcion", "Estreno", "EstudioFK", "GeneroFK", "Titulo" },
                values: new object[,]
                {
                    { 1, "Mientras rebuscan en las profundidades de una estación espacial abandonada, un grupo de jóvenes colonizadores del espacio se encuentra cara a cara con la forma de vida más aterradora del universo.", 2024, "20Century", "terror", "Alien Convenant" },
                    { 2, "Rumbo a un remoto planeta al otro lado de la galaxia, la tripulación de la nave colonial Covenant descubre lo que creen que es un paraíso inexplorado, pero resulta tratarse de un mundo oscuro y hostil cuyo único habitante es un \"sintético\" llamado David (Michael Fassbender), superviviente de la malograda expedición Prometheus.", 2017, "20Century", "terror", "Alien Romulus" },
                    { 3, "", 2019, "disney", "accion", "Avengers Endgame" },
                    { 4, "", 2018, "disney", "accion", "Avengers Infinity War" },
                    { 5, "", 2018, "paramount", "accion", "Mision Imposible Sentencia Mortal" },
                    { 6, "Un grupo de científicos y exploradores viajan a un remoto planeta en busca de respuestas sobre el origen de la humanidad, pero descubren una amenaza que podría poner en peligro su propia existencia.", 2012, "20Century", "terror", "Prometheus" },
                    { 7, "Una joven psiquiatra se enfrenta a una serie de eventos aterradores después de que un paciente comete suicidio frente a ella, dejando una maldición que la persigue.", 2022, "paramount", "terror", "Smile" },
                    { 8, "La estrella del pop mundial Skye Riley está a punto de embarcarse en una nueva gira mundial cuando empieza a experimentar una serie de sucesos cada vez más aterradores e inexplicables. Angustiada por la espiral de horrores y la abrumadora presión de la fama, Skye tendrá que enfrentarse a su oscuro pasado para recuperar el control de su vida antes de que sea demasiado tarde", 2024, "paramount", "terror", "Smile 2" },
                    { 9, "Un periodista y su productor consiguen una entrevista exclusiva con Kim Jong-Un, dictador de Corea del Norte. Ante tal oportunidad, la CIA les pide un \"favorcillo\": asesinar a Kim. Pero lo cierto es que Dave y Aaron no son las personas más cualificadas para realizar un magnicidio.", 2014, "columbia", "comedia", "The Interview" },
                    { 10, "", 2016, "columbia", "comedia", "This is the End" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Peliculas_EstudioFK",
                table: "Peliculas",
                column: "EstudioFK");

            migrationBuilder.CreateIndex(
                name: "IX_Peliculas_GeneroFK",
                table: "Peliculas",
                column: "GeneroFK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Peliculas");

            migrationBuilder.DropTable(
                name: "Estudios");

            migrationBuilder.DropTable(
                name: "Generos");
        }
    }
}
