using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppPeliculas.Models
{
    public class User :IdentityUser
    {

        // Propiedad para almacenar los roles del usuario
        //Esta propiedad no se mapeará a la base de datos
        //La clase User hereda de IdentityUser, que ya tiene propiedades como UserName, Email, PasswordHash, etc.
        [NotMapped]
        public IList<string> Roles { get; set; } = null!;
    }
}
