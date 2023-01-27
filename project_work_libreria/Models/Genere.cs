namespace project_work_libreria.Models
{
    public class Genere
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        List<Libro> Libri  { get; set; }
    }
}
