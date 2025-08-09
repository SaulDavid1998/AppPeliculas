using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using AppPeliculas.Models;

/*using AppPeliculas.Models;*/
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppPeliculas.Controllers
{
    public class HomeController : Controller
    {

        public PeliculaContext context = null!;

        public HomeController(PeliculaContext context)
        {
            this.context = context;
        }
        public IActionResult Index(string genero="todo", string estudio="todo")
        {
            ViewBag.Genero = genero;
            ViewBag.Estudio = estudio;
            ViewBag.lstGeneros = context.Generos.ToList();
            ViewBag.lstEstudios = context.Estudios.ToList();

            List<Pelicula> consulta = null!;

            if (genero == "todo" && estudio=="todo")
            {
                consulta = context.Peliculas
                    .Include(p=>p.Genero)
                    .Include(p=>p.Estudio)
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

    }
}
