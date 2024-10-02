using TipamCinemaTicker.Models;

namespace GestionCinema.Models
{
    public class Acteurs_Film
    {
        public int ActeurId { get; set; }
        public Acteurs Acteur { get; set; }
        public int FilmId { get; set; }
        public film  Film {get; set; }

    }
}
