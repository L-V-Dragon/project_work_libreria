
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project_work_libreria.Database;
using project_work_libreria.Models;


namespace project_work_libreria.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            using LibreriaContext db = new();
            List<Libro> listaLibri = db.Libri.OrderBy(x => x.Titolo).Include(x => x.Genere).ToList<Libro>();

            return View(listaLibri);
        }

        public IActionResult Dettagli(int id)
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

                return NotFound("Il libro con l'id cercato non esiste!");

            }
        }
        public IActionResult DettagliApi(int id)
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

                return NotFound("Il libro con l'id cercato non esiste!");

            }
        }

        [HttpGet]
        public IActionResult Ordine(int id)
        {
            using (LibreriaContext db = new LibreriaContext())
            {
                Libro libriFromDb = db.Libri.Where(SingoloLibroNelDb => SingoloLibroNelDb.Id == id).Include(Libro => Libro.Genere).FirstOrDefault();

                LibreriaView modelForView = new LibreriaView();

                modelForView.Libro = new Libro();
                modelForView.Ordine = new Ordine();
                modelForView.Genere = db.Genere.ToList();

                return View("Ordine", modelForView);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Ordine(LibreriaView formData)
        {
            if (!ModelState.IsValid)

            {
                return View(formData);
            }

            using (LibreriaContext db = new LibreriaContext())
            {
                formData.Ordine.Data = DateTime.Now;
                Libro libro = db.Libri.Where(SingoloLibroNelDb => SingoloLibroNelDb.Id == formData.Libro.Id).FirstOrDefault();
                libro.Quantita = libro.Quantita - formData.Ordine.Quantita;

                db.Ordine.Add(formData.Ordine);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
