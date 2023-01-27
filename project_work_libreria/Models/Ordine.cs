using System.ComponentModel.DataAnnotations;

namespace project_work_libreria.Models
{
    public class Ordine
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        public int Quantita { get; set; }

        [Required]
        public DateTime Data { get; set; }

        //Chiavi per relazioni con utente e libro
        public List<User>? nUtenti { get; set; }
        public List<Libro>? nLibri { get; set; }

        //Chiave per relazione 1 a N con fornitore
        public int FornitoreId { get; set; }
        public Fornitore? Fornitore { get; set; }

        //Costruttori
        public Ordine() { }
        public Ordine(int quantita)
        {
            Quantita = quantita;
            Data = DateTime.Now;  //funziona?
        }
    }
} 
