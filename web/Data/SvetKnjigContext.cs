using web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace web.Data
{
    public class SvetKnjigContext : IdentityDbContext<ApplicationUser>
    {
        public SvetKnjigContext(DbContextOptions<SvetKnjigContext> options) : base(options)
        {
        }
        public DbSet<Avtor> Avtorji { get; set; }
        public DbSet<Knjiga> Knjige { get; set; }
        public DbSet<Zanr> Zanr { get; set; }
        public DbSet<Uporabnik> Uporabniki { get; set; }
        public DbSet<Ocene_komentarji> Ocene_Komentarji { get; set; }
        public DbSet<Knjiga_avtor> Knjige_avtorji { get; set; }
        public DbSet<Knjiga_zanr> Knjige_zanri { get; set; }
        public DbSet<Izposoja_nakup> Izposoje_nakupi { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Avtor>().ToTable("Avtor");
            modelBuilder.Entity<Knjiga>().ToTable("Knjiga");
            modelBuilder.Entity<Zanr>().ToTable("Zanr");
            modelBuilder.Entity<Uporabnik>().ToTable("Uporabnik");
            modelBuilder.Entity<Ocene_komentarji>().ToTable("Ocene_komentarji");
            modelBuilder.Entity<Knjiga_avtor>().ToTable("Knjiga_avtor");
            modelBuilder.Entity<Knjiga_zanr>().ToTable("Knjiga_zanr");
            modelBuilder.Entity<Izposoja_nakup>().ToTable("Izposoja_nakup");
        }
    }
}