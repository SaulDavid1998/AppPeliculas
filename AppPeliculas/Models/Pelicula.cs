using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppPeliculas.Models
{
    public class Pelicula
    {
        [Key]
        public int PeliculaId { get; set; }

        [Required(ErrorMessage ="El campo Titulo es obligatorio")]
        public string Titulo { get; set; }=string.Empty;

        [StringLength(400,ErrorMessage ="El campo Descripcion no debe exceder los 400 caracteres")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage ="El campo Estreno es obligario")]
        [Range(1900,2040,ErrorMessage = "Valor admitido para campo Estreno debe ser entre 1900 y 2040")]
        public int? Estreno { get; set; }

        [Required(ErrorMessage ="El campo Duracion es obligatorio")]
        [Range(1, 300, ErrorMessage = "Valor admitido para campo Duracion debe ser entre 1 y 300")]
        public int? Duracion { get; set; }
        public string Slug
        {
            get
            {
                return Titulo + "-" + Estreno;
            }
        }

        public string GeneroFK { get; set; }=string.Empty;

        [ForeignKey("GeneroFK")]
        [ValidateNever]
        public Genero Genero { get; set; } = null!;


        public string EstudioFK { get; set; } = string.Empty;

        [ForeignKey("EstudioFK")]
        [ValidateNever]
        public Estudio Estudio { get; set; } = null!;

    }
}
