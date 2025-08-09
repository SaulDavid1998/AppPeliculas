using AppPeliculas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace AppPeliculas.Controllers
{
    public class PeliculaController : Controller
    {
        private PeliculaContext context= null!;

        public PeliculaController(PeliculaContext context)
        {
            this.context = context;
        }

        public IActionResult Detalle(int id,string slug)
        {

            var pelicula = context.Peliculas.Where(p => p.PeliculaId == id)
                .Include(p => p.Genero)
                .Include(p => p.Estudio)
                .FirstOrDefault();

            ViewBag.ImagenUrl=pelicula.Titulo+".jpg";
            if (pelicula == null)
            {
                return NotFound();
            }


            return View(pelicula);
        }

       

        [HttpPost] 
        public IActionResult AgregarFavorito(int PeliculaId)
        {
            var objPelicula = context.Peliculas
                                    .Where(p => p.PeliculaId == PeliculaId)
                                    .Include(g => g.Genero)
                                    .Include(e => e.Estudio)
                                    .FirstOrDefault();
            TempData["favoritos"] = objPelicula.Titulo + " agregado a Favoritos";

            var lstFavoritos = HttpContext.Session.GetObjectFromJson<List<Pelicula>>("Favoritos");

            if (lstFavoritos == null)
            {
                lstFavoritos = new List<Pelicula>();
            }

            lstFavoritos.Add(objPelicula);
            HttpContext.Session.SetObject("Favoritos", lstFavoritos);
            HttpContext.Session.SetInt32("contador_Favoritos", lstFavoritos.Count);
            return RedirectToAction("Detalle", "Pelicula", new {id=objPelicula.PeliculaId,slug=objPelicula.Slug});
                                    
        }

        

        public IActionResult EliminarFavorito (int PeliculaId)
        {
            var objPelicula = context.Peliculas
                                    .Where(p => p.PeliculaId == PeliculaId)
                                    .Include(g => g.Genero)
                                    .Include(e => e.Estudio)
                                    .FirstOrDefault();

            TempData["favoritos"] = objPelicula.Titulo + " eliminado de Favoritos";
            var lstFavoritos = HttpContext.Session.GetObjectFromJson<List<Pelicula>>("Favoritos");

            Pelicula pelicula = null;

            foreach (var registro in lstFavoritos)
            {
                if(registro.PeliculaId == PeliculaId)
                {
                    pelicula = registro;
                    lstFavoritos.Remove(pelicula);
                    break;
                }
            }
            HttpContext.Session.SetObject("Favoritos", lstFavoritos);
            HttpContext.Session.SetInt32("contador_Favoritos", lstFavoritos.Count);

            return RedirectToAction("Detalle", "Pelicula", new { id = objPelicula.PeliculaId, slug = objPelicula.Slug });
        }

        public IActionResult Favoritos()
        {
            var lstFavoritos = HttpContext.Session.GetObjectFromJson<List<Pelicula>>("Favoritos");
            return View(lstFavoritos);
        }


    }
}
