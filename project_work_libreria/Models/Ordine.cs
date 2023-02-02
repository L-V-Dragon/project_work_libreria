using System.ComponentModel.DataAnnotations;

namespace project_work_libreria.Models
{
    public class Ordine
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        [Range(1, 100, ErrorMessage = "Il numero deve essere compreso tra 1 e 100.")]  //mettere un altro messaggio di errore?
        public int Quantita { get; set; }

        [Required]
        public DateTime Data { get; set; }

        //Chiavi per relazioni con utente e libro
        public List<Libro>? ListaLibri { get; set; }
        //public List<Utente>? Utenti { get; set; }

        public int? Prezzo { get; set; }

        //Chiave per relazione 1 a N con fornitore
        public int FornitoreId { get; set; }
        public Fornitore? Fornitore { get; set; }

        //Costruttori
        public Ordine() { }
        
    }
} 
