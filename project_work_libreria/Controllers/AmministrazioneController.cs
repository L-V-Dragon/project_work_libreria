using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;
using project_work_libreria.Database;
using project_work_libreria.Models;

namespace project_work_libreria.Controllers
{
    public class AmministrazioneController : Controller
    {
        public IActionResult Index()
        {
            using (LibreriaContext db = new LibreriaContext())
            {
                List<Libro> listaLibri = db.Libri.Include(Libro => Libro.Genere).OrderBy(x=>x.Quantita).ToList<Libro>();

                return View(listaLibri);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            using LibreriaContext db = new LibreriaContext();
            {
                Libro libroDaEliminare = db.Libri.Where(Libro => Libro.Id == id).FirstOrDefault();

                if (libroDaEliminare != null)
                {
                    db.Libri.Remove(libroDaEliminare);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound("Il libro da eliminare non è stato trovato!");
                }
            }
        }

        [HttpGet]
        public IActionResult Create() { 
        
            using(LibreriaContext db= new LibreriaContext())
            {
                List<Genere> genereDalDb= db.Genere.ToList<Genere>();
                LibreriaView modelForView = new LibreriaView();
                modelForView.Libro = new Libro();
                modelForView.Genere = genereDalDb;
                return View("Create", modelForView);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(LibreriaView formdata) { 
        
            if(!ModelState.IsValid)
            {
                using(LibreriaContext db = new LibreriaContext())
                {
                    List<Genere> generi = db.Genere.ToList<Genere>();
                    formdata.Genere = generi;
                    
                }
                return View("Create", formdata);
            }

            using (LibreriaContext db = new LibreriaContext())
            {
                if (formdata.Libro.Like == null) {
                    formdata.Libro.Like = 0;
                    
                }
                formdata.Libro.Prezzo= ((int)(formdata.Libro.Prezzo*100)/100.00);
                db.Libri.Add(formdata.Libro);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            using(LibreriaContext db= new LibreriaContext())
            {
                Libro libroDaAggiornare= db.Libri.Where(Libro=> Libro.Id==id).FirstOrDefault();

                if(libroDaAggiornare == null)
                {
                    return NotFound("Il libro non è stato trovato");
                }
                else
                {
                    List<Genere> generi = db.Genere.ToList<Genere>();

                    LibreriaView modelForView = new LibreriaView();
                    modelForView.Libro = libroDaAggiornare;
                    modelForView.Genere = generi;

                    return View("Update", modelForView);
                }
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, LibreriaView formData)
        {
            if (!ModelState.IsValid)
            {
                using (LibreriaContext db = new LibreriaContext())
                {
                    List<Genere> generi = db.Genere.ToList<Genere>();
                    formData.Genere = generi;
                }

                return View("Update",formData);
            }

            using (LibreriaContext db = new LibreriaContext())
            {
                Libro libroDaAggiornare= db.Libri.Where(Libro=> Libro.Id==id).FirstOrDefault();

                if (libroDaAggiornare != null)
                {
                    libroDaAggiornare.Titolo = formData.Libro.Titolo;
                    libroDaAggiornare.Trama = formData.Libro.Trama;
                    libroDaAggiornare.Prezzo = formData.Libro.Prezzo = ((int)(formData.Libro.Prezzo * 100) / 100.00); ;
                    libroDaAggiornare.GenereId = formData.Libro.GenereId;
                    libroDaAggiornare.Quantita = formData.Libro.Quantita;
                    libroDaAggiornare.Foto = formData.Libro.Foto;

                    db.SaveChanges();
                    return RedirectToAction("Index");


                }
                else
                {
                    return NotFound("Il libro non è stato trovato!");
                }
            }
        }

        [HttpGet]
        public IActionResult Ordine(int id)
        {
            using (LibreriaContext db = new LibreriaContext())

            {
                List<Fornitore> categoriesFromDb = db.Fornitore.ToList<Fornitore>();

                Libro libroFromDb = db.Libri
                    .Where(SingoloLibroNelDb => SingoloLibroNelDb.Id == id)
                    .Include(Libro => Libro.Genere)
                    .FirstOrDefault();

                LibreriaView modelForView = new LibreriaView();

                modelForView.Libro = libroFromDb;

                modelForView.Fornitore = categoriesFromDb;
               


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
                libro.Quantita = libro.Quantita + formData.Ordine.Quantita;

                db.Ordine.Add(formData.Ordine);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

    }
}
