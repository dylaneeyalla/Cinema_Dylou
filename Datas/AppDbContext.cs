using GestionCinema.Models;
using Microsoft.EntityFrameworkCore;
using TipamCinemaTicker.Models;

namespace TipamCinemaTicker.Datas
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {
                 
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //on precise que la table Acteurs_Film contient les id de Acteur et Film
            modelBuilder.Entity<Acteurs_Film>().HasKey(af => new
            { 
                af.ActeurId,
                af.FilmId
            });
            //on precise qu'un film peut avoir un ou plusieur acteurs et qu'il est cle etrangere dans la table Acteur_Films
            modelBuilder.Entity<Acteurs_Film>().HasOne(f => f.Film).WithMany(af=>af.Acteurs_Films)
                                                                    .HasForeignKey(af=>af.FilmId);
            //on precise qu'un Acteur peut avoir un ou plusieur film et qu'il est cle etrangere dans la table Acteurs_Films
            modelBuilder.Entity<Acteurs_Film>().HasOne(af => af.Acteur).WithMany(af => af.Acteurs_Films)
                                                                    .HasForeignKey(af => af.ActeurId);

            base.OnModelCreating(modelBuilder); 
        }
        public DbSet<Acteurs> Acteurs { get; set;}
        public DbSet<film> Film { get; set;}
        public DbSet<Acteurs_Film> Acteurs_Films { get; set;}
    }
}
