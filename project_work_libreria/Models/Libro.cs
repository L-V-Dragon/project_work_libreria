using System.ComponentModel.DataAnnotations;

namespace project_work_libreria.Models {
    public class Libro {

        [Key]
        public int Id { get; set; }

        public string Titolo { get; set; }

        public Libro() { }



    }
}
