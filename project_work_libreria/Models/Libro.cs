using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using project_work_libreria.CustomValidation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Security.Policy;

namespace project_work_libreria.Models {
    public class Libro {

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(15)]
        [IsbnValidation]
        public string Isbn { get; set; }

        [Required]
        public string Titolo { get; set; }

        [Required]
        public string Trama { get; set; }

        [Required]
        public string Autore { get; set; }

        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        [Url(ErrorMessage = "Hai inserito un link non valido")]
        [ImageUrlValidation]
        public string Foto { get; set; }

        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        public double Prezzo { get; set; }

        public int? Quantita { get; set; }

        public int? Like { get; set; }

        public int? GenereId { get; set; }
        public Genere? Genere { get; set; }

        public Libro() { }

        public double StampaPrezzo()
        {
            return Math.Round(Prezzo, 2);
        }
    }
}
