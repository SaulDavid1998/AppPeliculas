using System.ComponentModel.DataAnnotations;

namespace AppPeliculas.Models
{
    public class Registro
    {
        [Required(ErrorMessage = "Falta el nombre de usuario")]
        [StringLength(255)]
        public string Usuario { get; set; } = string.Empty;

        [Required(ErrorMessage = "Falta la contraseña ")]
        [DataType(DataType.Password)]
        [Compare("ConfirmarContraseña", ErrorMessage = "Las contraseñas no coinciden")]
        public string Contraseña { get; set; } = string.Empty;

        [Required(ErrorMessage = "Falta la confirmación de contraseña")]
        [DataType(DataType.Password)]
        public string ConfirmarContraseña { get; set; } = string.Empty;
    }
}
