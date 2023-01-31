using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project_work_libreria.Database;
using project_work_libreria.Models;
using System.Diagnostics;

namespace project_work_libreria.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            using (LibreriaContext db = new LibreriaContext())
            {
                List<Libro> listaLibri = db.Libri.Include(Libro => Libro.Genere).OrderBy(x => x.Quantita).ToList<Libro>();

                return View(listaLibri);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}