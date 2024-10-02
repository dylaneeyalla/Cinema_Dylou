using GestionCinema.Models;
using System.ComponentModel.DataAnnotations;
using TipamCinemaTicker.Datas.Enums;

namespace GestionCinema.Models
{
    public class film
    {
        [Key] public int Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public string photo { get; set; }

        public double Prix { get; set; }

        public DateTime Debut { get; set; }
        public DateTime Fin { get; set; }
        public FilmCathegorie FilmCategorie {get;set;}
        public List<Acteurs_Film> Acteurs_Films { get; set;}


    }
}
