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
                list = db.Libri.Include(x=> x.Genere).ToList();
                return Ok(list);
            } else {
                search = search.ToLower();
                list=db.Libri.Include(x=>x.Genere).ToList()
                    .Where(x=> x.Titolo.ToLower().Contains(search) || 
                    x.Genere.Nome.ToLower() == search).ToList();
                return Ok(list);
            }

        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {

            using (LibreriaContext db = new LibreriaContext())
            {
                Libro libro = db.Libri.Where(libro => libro.Id == id).FirstOrDefault();

                if (libro is null)
                {
                    return NotFound("Il libro con questo id non è stato trovato!");
                }

                return Ok(libro);
            }
        }
    }
}
