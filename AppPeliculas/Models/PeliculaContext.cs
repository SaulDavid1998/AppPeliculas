using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AppPeliculas.Models
{
    public class PeliculaContext: IdentityDbContext
    {
        public PeliculaContext(DbContextOptions<PeliculaContext> options) : base(options)
        {
        }

        public DbSet<Pelicula> Peliculas { get; set; } = null!;
        public DbSet<Genero> Generos { get; set; } = null!;

        public DbSet<Estudio> Estudios { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Estudio>().HasData(
                new Estudio { EstudioID = "disney", EstudioNombre = "Disney" },
                new Estudio { EstudioID = "columbia", EstudioNombre = "Columbia Pictures" },
                new Estudio { EstudioID = "paramount", EstudioNombre = "Paramount Pictures" },
                new Estudio { EstudioID = "20Century", EstudioNombre = "20 Century" }
                );

            modelBuilder.Entity<Genero>().HasData(
                new Genero { GeneroID = "accion", GeneroNombre = "Accion" },
                new Genero { GeneroID = "comedia", GeneroNombre = "Comedia" },
                new Genero { GeneroID = "terror", GeneroNombre = "Terror" }
                );

            modelBuilder.Entity<Pelicula>().HasData(
                new Pelicula
                {
                    PeliculaId = 1,
                    Titulo = "Alien Covenant",
                    Descripcion = "Mientras rebuscan en las profundidades de una estación espacial abandonada, un grupo de jóvenes colonizadores del espacio se encuentra cara a cara con la forma de vida más aterradora del universo.",
                    Estreno = 2024,
                    GeneroFK = "terror",
                    EstudioFK = "20Century",
                    Duracion = 120
                },
                new Pelicula
                {
                    PeliculaId = 2,
                    Titulo = "Alien Romulus",
                    Descripcion ="Rumbo a un remoto planeta al otro lado de la galaxia, la tripulación de la nave colonial Covenant descubre lo que creen que es un paraíso inexplorado, pero resulta tratarse de un mundo oscuro y hostil cuyo único habitante es un \"sintético\" llamado David (Michael Fassbender), superviviente de la malograda expedición Prometheus.",
                    Estreno = 2017,
                    GeneroFK = "terror",
                    EstudioFK = "20Century",
                    Duracion=120
                },
                new Pelicula
                { 
                    PeliculaId = 3,
                    Titulo = "Avengers Endgame",
                    Descripcion = "", Estreno = 2019,
                    GeneroFK = "accion",
                    EstudioFK = "disney",
                    Duracion=120
                },
                new Pelicula 
                {
                    PeliculaId = 4,
                    Titulo = "Avengers Infinity War",
                    Descripcion = "",
                    Estreno = 2018,
                    GeneroFK = "accion",
                    EstudioFK = "disney",
                    Duracion= 120
                },
                new Pelicula 
                { 
                    PeliculaId = 5,
                    Titulo = "Mision Imposible Sentencia Mortal",
                    Descripcion = "", 
                    Estreno = 2018, 
                    GeneroFK = "accion",
                    EstudioFK = "paramount",
                    Duracion=120
                },
                new Pelicula
                {
                    PeliculaId = 6,
                    Titulo = "Prometheus",
                    Descripcion = "Un grupo de científicos y exploradores viajan a un remoto planeta en busca de respuestas sobre el origen de la humanidad, pero descubren una amenaza que podría poner en peligro su propia existencia.",
                    Estreno = 2012,
                    GeneroFK = "terror",
                    EstudioFK = "20Century",
                    Duracion = 120
                },
                new Pelicula
                {
                    PeliculaId = 7,
                    Titulo = "Smile",
                    Descripcion = "Una joven psiquiatra se enfrenta a una serie de eventos aterradores después de que un paciente comete suicidio frente a ella, dejando una maldición que la persigue.",
                    Estreno = 2022,
                    GeneroFK = "terror",
                    EstudioFK = "paramount",
                    Duracion=120
                },
                new Pelicula
                {
                    PeliculaId = 8,
                    Titulo = "Smile 2",
                    Descripcion = "La estrella del pop mundial Skye Riley está a punto de embarcarse en una nueva gira mundial cuando empieza a experimentar una serie de sucesos cada vez más aterradores e inexplicables. Angustiada por la espiral de horrores y la abrumadora presión de la fama, Skye tendrá que enfrentarse a su oscuro pasado para recuperar el control de su vida antes de que sea demasiado tarde",
                    Estreno = 2024,
                    GeneroFK = "terror",
                    EstudioFK = "paramount",
                    Duracion = 120
                },
                new Pelicula
                {
                    PeliculaId = 9,
                    Titulo = "The Interview",
                    Descripcion = "Un periodista y su productor consiguen una entrevista exclusiva con Kim Jong-Un, dictador de Corea del Norte. Ante tal oportunidad, la CIA les pide un \"favorcillo\": asesinar a Kim. Pero lo cierto es que Dave y Aaron no son las personas más cualificadas para realizar un magnicidio.",
                    Estreno = 2014,
                    GeneroFK = "comedia",
                    EstudioFK = "columbia",
                    Duracion = 120
                },
                new Pelicula
                { PeliculaId = 10,
                  Titulo = "This is the End",
                  Descripcion = "",
                  Estreno = 2016,
                  GeneroFK = "comedia",
                  EstudioFK = "columbia",
                  Duracion = 120
                }
            );
        }
    }
}
