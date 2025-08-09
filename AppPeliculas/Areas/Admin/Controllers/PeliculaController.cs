using AppPeliculas.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppPeliculas.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class PeliculaController : Controller
    {
        private PeliculaContext context = null!;

        public PeliculaController(PeliculaContext context)
        {
            this.context = context;
        }

        public IActionResult Index(string genero = "todo", string estudio = "todo")
        {
            ViewBag.Genero = genero;
            ViewBag.Estudio = estudio;
            ViewBag.lstGeneros = context.Generos.ToList();
            ViewBag.lstEstudios = context.Estudios.ToList();

            List<Pelicula> consulta = null!;

            if (genero == "todo" && estudio == "todo")
            {
                consulta = context.Peliculas
                    .Include(p => p.Genero)
                    .Include(p => p.Estudio)
                    .OrderBy(p => p.Estreno)
                    .ToList();

            }
            else
            {
                if (genero != "todo" && estudio != "todo")
                {
                    consulta = context.Peliculas
                        .Where(p => p.Genero.GeneroID == genero)
                        .Where(p => p.Estudio.EstudioID == estudio)
                        .Include(p => p.Genero)
                        .Include(p => p.Estudio)
                        .ToList();
                }
                else
                {
                    if (genero != "todo")
                    {
                        consulta = context.Peliculas
                            .Where(p => p.Genero.GeneroID == genero)
                            .Include(p => p.Genero)
                            .Include(p => p.Estudio)
                            .ToList();
                    }
                    else

                    {
                        consulta = context.Peliculas
                            .Where(p => p.Estudio.EstudioID == estudio)
                            .Include(p => p.Genero)
                            .Include(p => p.Estudio)
                            .ToList();
                    }

                }

            }
            return View(consulta);
        }


        [HttpGet]
        public IActionResult Modificar(int id, string slug)
        {
            Pelicula pelicula = context.Peliculas.Find(id);

            ViewBag.lstGeneros = context.Generos.ToList();
            ViewBag.lstEstudios = context.Estudios.ToList();

            if (pelicula == null)
            {
                return NotFound();
            }

            return View(pelicula);
        }

        [HttpPost]
        public IActionResult Modificar(Pelicula objPelicula)
        {
            if (string.IsNullOrEmpty(objPelicula.Descripcion))
            {
                objPelicula.Descripcion = string.Empty;
            }
            if (ModelState.IsValid)
            {
                context.Peliculas.Update(objPelicula);
                context.SaveChanges();
                return RedirectToAction("Index", "Pelicula");
            }
            else
            {
                ViewBag.lstGeneros = context.Generos.ToList();
                ViewBag.lstEstudios = context.Estudios.ToList();
                return View(objPelicula);
            }
        }
    }
}
