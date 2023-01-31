using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project_work_libreria.Database;
using project_work_libreria.Models;

namespace project_work_libreria.Controllers {
    public class ClienteController : Controller {
        public IActionResult Index() {
            using LibreriaContext db = new();
            List<Libro> listaLibri = db.Libri.OrderBy(x => x.Titolo).Include(x=> x.Genere).ToList<Libro>();

            return View(listaLibri);
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
        public IActionResult DettagliApi(int id) {
            using (LibreriaContext db = new LibreriaContext()) {

                Libro libroTrovato = db.Libri
                    .Where(SingoloLibroNelDb => SingoloLibroNelDb.Id == id)
                    .Include(Libro => Libro.Genere)
                    .FirstOrDefault();

                if (libroTrovato != null) {
                    return View(libroTrovato);
                }

                return NotFound("Il libro con l'id cercato non esiste!");

            }
        }

        public IActionResult Ordine(int id)
        {
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

                return NotFound("Il libro con l'id cercato non esiste!")
            }
        }
    }
}
