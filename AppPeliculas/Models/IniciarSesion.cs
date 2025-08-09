using System.ComponentModel.DataAnnotations;

namespace AppPeliculas.Models
{
    public class IniciarSesion
    {
        [Required(ErrorMessage = "Falta el nombre de usuario")]
        public string Usuario { get; set; } = string.Empty;

        [Required(ErrorMessage = "Falta la contraseña")]
        public string Contraseña { get; set; } = string.Empty;

        public string ReturnUrl { get; set; } = string.Empty;

        
    }

    
    
}
