using System.ComponentModel.DataAnnotations;

namespace project_work_libreria.Models {
    public class Libro {

        [Key]
        public int Id { get; set; }

        public string Titolo { get; set; }

        public string Trama { get; set; }

        public string Foto { get; set; }
            
        public int Prezzo { get; set; }

        public int? Quantita { get; set; }

        public int? Like { get; set; }

        public int GenereId { get; set; }
        public Genere Genere { get; set; }

        public Libro() { }



    }
}
