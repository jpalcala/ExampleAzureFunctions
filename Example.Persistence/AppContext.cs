using Example.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Example.Persistence
{
    public class AppContext : DbContext
    {
        public AppContext()
        {

        }
        public AppContext(DbContextOptions<AppContext> options): base(options)
        {  }

        public DbSet<Person> Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlite("Filename=TestDatabase.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppContext).Assembly);
        }

    }
}
