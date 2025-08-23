using AppPeliculas.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AppPeliculas.Controllers
{
    public class CuentaController : Controller
    {
        private UserManager<IdentityUser> userManager = null!;
        private SignInManager<IdentityUser> signInManager = null!;

        public CuentaController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Registrarse()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrarse(Registro objRegistro)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = objRegistro.Usuario,
                };

                var resultado = await userManager.CreateAsync(user, objRegistro.Contraseña);
                if (resultado.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in resultado.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return View(objRegistro);
        }

        [HttpPost]
        public async Task<IActionResult> CerrarSesion()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("Account/LogIn")]
        public IActionResult IniciarSesion(string returnUrl = "")
        {
            var IniciarSesion = new IniciarSesion
            {
                ReturnUrl = returnUrl
            };
            return View(IniciarSesion);
        }

        [HttpPost]
        [Route("Account/LogIn")]
        public async Task<IActionResult> IniciarSesion(IniciarSesion objIniciarSesion)
        {
            if (ModelState.IsValid)
            {
                var resultado = await signInManager.PasswordSignInAsync(objIniciarSesion.Usuario, objIniciarSesion.Contraseña, isPersistent: false, lockoutOnFailure: false);
                if (resultado.Succeeded)
                {
                    if (!string.IsNullOrEmpty(objIniciarSesion.ReturnUrl) && Url.IsLocalUrl(objIniciarSesion.ReturnUrl))
                    {
                        return Redirect(objIniciarSesion.ReturnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Nombre de usuario o contraseña incorrectos");
                }
            }
            return View(objIniciarSesion);
        }


    }
}
