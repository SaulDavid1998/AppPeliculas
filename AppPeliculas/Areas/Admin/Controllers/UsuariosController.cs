using AppPeliculas.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppPeliculas.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsuariosController : Controller
    {
        public UserManager<User> Usuario = null!;
        public RoleManager<IdentityRole> Rol = null!;
        public UsuariosController(UserManager<User> userManager,RoleManager<IdentityRole> roleManager)
        {
            Usuario = userManager;
            Rol = roleManager;
        }

        public async Task<ActionResult> Index()
        {
            var usuariosDb = await Usuario.Users.ToListAsync();
            List<User> usuarios = [];

            foreach (User usuario in usuariosDb)
            {
                usuario.Roles = await Usuario.GetRolesAsync(usuario);
                usuarios.Add(usuario);
            }

            return View(usuarios);

        }

        


    }
}
