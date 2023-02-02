namespace project_work_libreria.Models
{
    public class LibreriaView
    {
        public Libro Libro { get; set; }

        public Ordine? Ordine { get; set; }
        public List<Genere>? Genere { get; set; }

        public List<Fornitore>? Fornitore { get; set;}

    }
}
