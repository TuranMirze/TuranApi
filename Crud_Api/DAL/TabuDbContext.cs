using Crud_Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Crud_Api.DAL
{
    public class TabuDbContext : DbContext
    {
        public TabuDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Word> Words { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof
                (TabuDbContext).Assembly);
            

            base.OnModelCreating(modelBuilder);
        }
    }
}
