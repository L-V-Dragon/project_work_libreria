using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using project_work_libreria.Models;

namespace project_work_libreria.Database {
    public class LibreriaContext: IdentityDbContext<IdentityUser> {

        public DbSet<Libro> Libri { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer("Data Source=localhost;Database=Libreria1DB;Integrated Security=True;TrustServerCertificate=True");

        }
        
        
    }
}
