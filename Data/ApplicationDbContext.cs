using Microsoft.EntityFrameworkCore;
using BibliotecaAsp.Models;

namespace BibliotecaAsp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> o) : base(o) { }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
