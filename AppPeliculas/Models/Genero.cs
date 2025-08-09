using System.ComponentModel.DataAnnotations;

namespace AppPeliculas.Models
{
    public class Genero
    {
        [Key]
        public string GeneroID { get; set; } = string.Empty;

        public string GeneroNombre {  get; set; } = string.Empty;
    }
}
