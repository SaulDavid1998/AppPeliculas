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

        public async Task<ActionResult> AgregarAdmin(string id)
        {
            User usuario = await Usuario.FindByIdAsync(id);

            var rolesUsuario = await Usuario.GetRolesAsync(usuario);
            if (rolesUsuario.Contains("Administrador"))
            {
                TempData["Mensaje"] = "Usuario "+usuario.UserName+ " ya está registrado como Administrador.";
                return RedirectToAction("Index");
            }

            await Usuario.AddToRoleAsync(usuario, "Administrador");
            TempData["Mensaje"] = "Usuario "+usuario.UserName +" agregado como Administrador correctamente.";
            return RedirectToAction("Index", "Usuarios");
        }

        public async Task<ActionResult> EliminarAdmin(string id)
        {
            User usuario = await Usuario.FindByIdAsync(id);
            await Usuario.RemoveFromRoleAsync(usuario, "Administrador");
            TempData["Mensaje"] = "Usuario " + usuario.UserName + " eliminado como Administrador.";
            return RedirectToAction("Index");
        }



    }
}
