using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using project_work_libreria.Models;

namespace project_work_libreria.Database {
    public class LibreriaContext: IdentityDbContext<IdentityUser> {

        public DbSet<Libro> Libri { get; set; }

        public DbSet<Ordine> Ordine { get; set; }

        public DbSet<OrdineCliente> OrdineCliente { get; set; }
        public DbSet<Fornitore> Fornitore { get; set; }


        public DbSet<Genere> Genere { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer("Data Source=localhost;Database=LibreriaDB;Integrated Security=True;TrustServerCertificate=True");

        }
        
        
    }
}
