using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project_work_libreria.Database;
using project_work_libreria.Models;

namespace project_work_libreria.Controllers {
    public class ClienteController : Controller {
        public IActionResult Index() {
            return View();
        }

        public IActionResult Dettagli(int id) {
            using (LibreriaContext db = new LibreriaContext())
            {
               
                Libro libroTrovato = db.Libri
                    .Where(SingoloLibroNelDb => SingoloLibroNelDb.Id == id)
                    .Include(Libro => Libro.Genere)
                    .FirstOrDefault();

                if (libroTrovato != null)
                {
                    return View(libroTrovato);
                }

                return NotFound("Il libro con l'id cercato non esiste!");

            }
          
        }
    }
}
