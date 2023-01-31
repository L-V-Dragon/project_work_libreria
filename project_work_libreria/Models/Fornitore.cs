using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project_work_libreria.Models
{
    public class Fornitore
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Libro> Libri { get; set; }

        public Fornitore() { }
    }
}
