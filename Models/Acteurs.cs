using System.ComponentModel.DataAnnotations;
using TipamCinemaTicker.Models;

namespace GestionCinema.Models
{
    public class Acteurs
    {
        public int Id { get; set; }
        // on utilise required pour preciser que le nom est obligatoire
        [Required(ErrorMessage =" Le nom est obligatoire")]
        // definir la taille minimale et maximale du champ nom
        [StringLength(50,MinimumLength =2,ErrorMessage ="le nom doit etre compris entre 2 et 50 caracteres")]
        public string Nom { get; set; }

        // les annotations
        [Display(Name = "Photo de Profil")]
        [Required(ErrorMessage = " La photo  de profil est obligatoire")]

        public string photoProfil { get; set; }
        [Required(ErrorMessage = " Le Profil est obligatoire")]
        public string profil { get; set; }

        [Required(ErrorMessage = " La biographie est obligatoire")]
        public string Biographie { get; set; }

        public List<Acteurs_Film> Acteurs_Films { get; set; }

    }
}
