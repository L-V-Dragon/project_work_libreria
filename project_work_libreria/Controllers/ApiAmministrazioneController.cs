using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project_work_libreria.Database;
using project_work_libreria.Models;

namespace project_work_libreria.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class ApiAmministrazioneController : ControllerBase {

        [HttpGet]
        public IActionResult Get(string? search) {

            using LibreriaContext db = new();
            List<Libro> list = new();
            if(search==null || search == "") {
                list = db.Libri.Include(x=> x.Genere).OrderBy(x => x.Quantita).ToList();
                return Ok(list);
            } else {
                search = search.ToLower();
                list=db.Libri.Include(x=>x.Genere).ToList().OrderBy(x => x.Quantita)
                    .Where(x=> x.Titolo.ToLower().Contains(search) || 
                    x.Genere.Nome.ToLower().Contains(search) || x.Isbn.ToLower().Contains(search)||
                    x.Trama.ToLower().Contains(search)).ToList();
                return Ok(list);
            }

        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {

            using (LibreriaContext db = new LibreriaContext())
            {
                Libro libro = db.Libri.Include(x=>x.Genere).Where(libro => libro.Id == id).FirstOrDefault();

                if (libro is null)
                {
                    return NotFound("Il libro con questo id non è stato trovato!");
                }

                return Ok(libro);
            }
        }
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Like(int id, [FromBody]Libro libro) {
            using LibreriaContext db = new();
            Libro? libroDb= db.Libri.Where(x=>x.Id==libro.Id).FirstOrDefault();
            libroDb.Like = libro.Like;
            db.SaveChanges();
            return Ok(libro.Like);

        }
    }
}
