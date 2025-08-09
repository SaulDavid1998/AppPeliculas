using System.ComponentModel.DataAnnotations;

namespace AppPeliculas.Models
{
    public class Estudio
    {
        [Key]
        public string EstudioID { get; set; } = string.Empty;

        public string EstudioNombre {  get; set; } = string.Empty;
    }
}
