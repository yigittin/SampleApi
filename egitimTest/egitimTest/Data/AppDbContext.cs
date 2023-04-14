
using egitimTest.Modals.Books;
using Microsoft.EntityFrameworkCore;

namespace egitimTest.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.;Database=egitimTest;Trusted_Connection=true;TrustServerCertificate=true;");
        }

        public DbSet<Book> Book { get; set; }
    }
}
