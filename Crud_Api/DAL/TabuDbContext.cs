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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>(b =>
            {
                b.HasKey(x => x.Code);
                b.HasIndex(x => x.Name)
                .IsUnique();
                b.Property(x => x.Code)
                .IsFixedLength(true)
                .HasMaxLength(2);
                b.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(32);
                b.Property(x => x.Icon)
                .HasMaxLength(128);
                b.HasData(new Language
                {
                    Code = "az",
                    Name = "Azerbaycan",
                    Icon = "https://cdn-icons-png.flaticon.com/512/630/630657.png"


                });
            });
            modelBuilder.Entity<Word>(b =>
            {
                b.Property(x => x.Text)
                    .IsRequired()
                    .HasMaxLength(32);
                b.HasOne(x => x.Language)
                    .WithMany(x => x.Words)
                    .HasForeignKey(x => x.LangCode);
                b.HasMany(x => x.BannedWords)
                .WithOne(x => x.Word)
                .HasForeignKey(x => x.WordId);
            });

            modelBuilder.Entity<Word>(b =>
            {               
                b.HasOne(x => x.Language)
                    .WithMany(x => x.Words)
                    .HasForeignKey(x => x.LangCode);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
