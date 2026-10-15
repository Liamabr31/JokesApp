using JokesApp.Models;
using Microsoft.EntityFrameworkCore;

namespace JokesApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Joke> Joke { get; set; } = null!;
    }
}
