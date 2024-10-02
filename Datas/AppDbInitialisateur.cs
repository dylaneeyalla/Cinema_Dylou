using GestionCinema.Models;
using TipamCinemaTicker.Datas.Enums;
using TipamCinemaTicker.Models;

namespace TipamCinemaTicker.Datas
{
    public class AppDbInitialisateur
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context=serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();

                //Acteur
                // on se rassure que les acteurs ne sont pas dans la bd
                if (!context.Acteurs.Any())
                {
                    context.Acteurs.AddRange(new List<Acteurs>()
                    {
                        new Acteurs()
                        {
                            Nom="Acteur1",
                            profil="acteur principale",
                            photoProfil="https://www.pexels.com/fr-fr/photo/lumineux-ville-art-rue-9316207/",
                            Biographie="information sur l'acteur"
                        },
                        new Acteurs()
                        {
                            Nom="Acteur2",
                            profil="Photographe",
                            photoProfil="https://www.pexels.com/fr-fr/photo/personne-femme-poser-cheveux-colores-4800598/",
                            Biographie="information sur l'acteur"
                        },
                          new Acteurs()
                        {
                            Nom="Acteur3",
                            profil="Animatrice",
                            photoProfil="https://www.pexels.com/fr-fr/photo/mode-rouge-amour-gens-19809164/",
                            Biographie="information sur l'acteur"
                        }
                    });
                    context.SaveChanges();
                }
                //Film
                // on se rassure que les Film ne sont pas dans la bd
                if (!context.Film.Any())
                {
                    context.Film.AddRange(new List<film>()
                    {
                        new film()
                        {
                            Nom="Film1",
                            Description="description du film",
                            photo="https://www.pexels.com/fr-fr/photo/outil-de-prise-de-scene-de-production-noir-et-blanc-918281/",
                           Prix=39.25,
                           Debut=DateTime.Now.AddDays(-10),
                           Fin=DateTime.Now.AddDays(-2),
                           FilmCategorie=FilmCathegorie.Aventure
                        },
                         new film()
                        {
                            Nom="Film2",
                            Description="description du film",
                            photo="https://www.pexels.com/fr-fr/photo/outil-de-prise-de-scene-de-production-noir-et-blanc-918281/",
                           Prix=10.25,
                           Debut=DateTime.Now.AddDays(-5),
                           Fin=DateTime.Now.AddDays(2),
                           FilmCategorie=FilmCathegorie.Horreur
                        },
                            new film()
                        {
                            Nom="Film3",
                            Description="description du film",
                            photo="https://www.pexels.com/fr-fr/photo/outil-de-prise-de-scene-de-production-noir-et-blanc-918281/",
                           Prix=25.25,
                           Debut=DateTime.Now.AddDays(-8),
                           Fin=DateTime.Now.AddDays(5),
                           FilmCategorie=FilmCathegorie.Comedie
                        }

                    });
                    context.SaveChanges();
                }
                //Acteur && Film
                // on se rassure que les acteurs_Film ne sont pas dans la bd
                if (!context.Acteurs_Films.Any())
                {
                    context.Acteurs_Films.AddRange(new List<Acteurs_Film>()
                    {
                        new Acteurs_Film()
                        {
                           ActeurId=4,
                           FilmId=2
                        },
                         new Acteurs_Film()
                        {
                           ActeurId=5,
                           FilmId=2
                        },
                        new Acteurs_Film()
                        {
                           ActeurId=6,
                           FilmId=1
                        }

                    });
                    context.SaveChanges();

                }
            }
        }
    }
}
