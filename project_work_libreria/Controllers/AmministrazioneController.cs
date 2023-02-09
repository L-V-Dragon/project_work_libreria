using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.SqlServer.Server;
using project_work_libreria.Database;
using project_work_libreria.Models;
using System.Data;

namespace project_work_libreria.Controllers
{
    [Authorize(Roles = "Admin")]
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
                Libro libroFromDb = db.Libri.Where(SingoloLibroNelDb => SingoloLibroNelDb.Id == id).Include(Libro => Libro.Genere).FirstOrDefault();
                List<Fornitore> fornitoreFromDb = db.Fornitore.ToList();
                LibreriaView modelForView = new LibreriaView();

                modelForView.Libro = libroFromDb;
                modelForView.Fornitore= fornitoreFromDb;
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
                Libro libro = db.Libri.Where(SingoloLibroNelDb => SingoloLibroNelDb.Id == formData.Libro.Id).FirstOrDefault();
                formData.Ordine.Data = DateTime.Now;
                formData.Ordine.Prezzo = libro.Prezzo * formData.Ordine.Quantita;
                formData.Ordine.Prezzo = ((int)(formData.Ordine.Prezzo * 100) / 100.00);
                libro.Quantita = libro.Quantita + formData.Ordine.Quantita;
                formData.Ordine.ListaLibri = new List<Libro> { libro };
                libro.Ordine = new List<Ordine> { formData.Ordine };
                db.Ordine.Add(formData.Ordine);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }


        //Comandi per gestire gli account registrati
        [HttpGet]
        public IActionResult ListaUtenti(string id) {
            LibreriaContext db = new();
            var Users = db.Users.ToList();
            List<UserForView> users = new();
            foreach (var user in Users) {
                UserForView RuoliUtente = new();
                var Ruoli= db.Roles.ToList();
                RuoliUtente.Ruoli = Ruoli;
                var RuoloUtente = db.UserRoles.Where(x => x.UserId== user.Id).FirstOrDefault();
                if(RuoloUtente is not null) {
                    string RuoloUtenteId = RuoloUtente.RoleId;
                    var RuoloPerUtente= db.Roles.Where(y=> y.Id==RuoloUtenteId).FirstOrDefault();
                    RuoliUtente.UserRuolo = RuoloPerUtente;
                } else {
                    RuoliUtente.UserRuolo= null;
                }
                RuoliUtente.User = user;
                users.Add(RuoliUtente);
                users=users.OrderBy(u => u.User.UserName).ToList();
            }
            return View(users);
        }

        [HttpGet]
        public IActionResult ModificaUtente(string id) {

            using LibreriaContext db = new();
            var User = db.Users.Where(x=>x.Id==id).FirstOrDefault();
            var Ruoli = db.Roles.ToList();
            var UserRuolo= db.UserRoles.Where(y=>y.UserId == User.Id).FirstOrDefault();
            UserForView UserModel = new();
            UserModel.User = User;          
            UserModel.Ruoli = Ruoli;
            if(UserRuolo is not null) {
                string IdRuolo = UserRuolo.RoleId;
                var RuoloPerUtente= db.Roles.Where(y => y.Id == IdRuolo).FirstOrDefault();
                UserModel.UserRuolo = RuoloPerUtente;
            } else {
                UserModel.UserRuolo= null;
            }


            return View(UserModel);
        }
        [HttpPost]
        public IActionResult ModificaUtente(UserForView formdata) {

            using LibreriaContext db = new();
            var user= db.Users.Where(x=> x.Id == formdata.User.Id).FirstOrDefault();
            var ruolo= db.Roles.Where(y=>y.Id == formdata.UserRuolo.Id).FirstOrDefault();
            if (ruolo == null) {
                IdentityUserRole<string> identityUserRole = new();
                identityUserRole.UserId = formdata.User.Id;
                identityUserRole.RoleId = formdata.UserRuolo.Id;
                db.UserRoles.Add(identityUserRole);
            } else {

                var ruoloUser = db.UserRoles.Where(x => x.UserId == formdata.User.Id).FirstOrDefault();
                if (ruoloUser == null) {
                    IdentityUserRole<string> identityUserRole = new();
                    identityUserRole.UserId = formdata.User.Id;
                    identityUserRole.RoleId = formdata.UserRuolo.Id;
                    db.UserRoles.Add(identityUserRole);
                } else {


                    db.Remove(ruoloUser);
                    db.SaveChanges();
                    IdentityUserRole<string> identityUserRole = new();
                    identityUserRole.UserId = formdata.User.Id;
                    identityUserRole.RoleId = formdata.UserRuolo.Id;
                    db.UserRoles.Add(identityUserRole);
                }
            }
                db.SaveChanges();
            return RedirectToAction("ListaUtenti");
        }

        public IActionResult RimuoviUtente(string id) {

            LibreriaContext db = new();
            var user = db.Users.Where(x=>x.Id == id).FirstOrDefault();
            db.Remove(user);
            db.SaveChanges();
            return RedirectToAction("ListaUtenti");
        }
    }
}
