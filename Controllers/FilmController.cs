using GestionCinema.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TipamCinemaTicker.Datas;

namespace TipamCinemaTicker.Controllers
{
    public class FilmController : Controller
    {
        private readonly AppDbContext _content;
        public FilmController(AppDbContext Context)
        {
            _content = Context;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _content.Film.ToListAsync();
            return View(data);
        }
        public async Task<IActionResult> VoirFilm()
        {
            var data = await _content.Film.ToListAsync();
            return View(data);
        }
        //Get:Acteurs/Create/1
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(film film)
        {
            try
            {
                if (_content.Acteurs.Any(d => d.Id.Equals(film.Id)))
                {
                    ViewBag.erreur = " Cet Acteur existe deja";
                    return View(film);
                }
                _content.Film.Add(film);
                await _content.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ViewBag.message = "Erreur : " + ex;
            }
            return RedirectToAction(nameof(Index));

            //return RedirectToAction("Index");
        }

        // creer la methode pour gerer la vue details
        public IActionResult Details(int id)
        {
            var FilmDetails = _content.Film.FirstOrDefault(acteur => acteur.Id == id);
            if (FilmDetails == null) return View("NotFound");
            return View(FilmDetails);
        }
        //Get:Acteurs/Edit/1
        public IActionResult Edit(int id)
        {
            var FilmDetails = _content.Film.FirstOrDefault(a => a.Id.Equals(id));
            if (FilmDetails == null)
            {
                return View("NotFound");
            }
            return View(FilmDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(film film)
        {
            var film1 = _content.Film.FirstOrDefault(d => d.Id == film.Id);
            if (film1 == null)
            {
                return View(film);
            }
            // modification des informations contenu dans la base de donnee
            film1.Nom = film.Nom;
            film1.Description = film.Description;
            film1.photo = film.photo;
            film1.Prix = film.Prix;
            film1.Debut = film.Debut;
            film1.Fin = film.Fin;
            film1.FilmCategorie = film.FilmCategorie;
            // enregistrement des informations de facon asynchrone avec la promesse await
            await _content.SaveChangesAsync();
            //return RedirectToAction("Index");
            return RedirectToAction(nameof(Index));
        }
        //Get:Acteurs/Delete/1
        public IActionResult Delete(int id)
        {
            var FilmDetails = _content.Film.FirstOrDefault(a => a.Id.Equals(id));
            if (FilmDetails == null)
            {
                return View("NotFound");
            }
            return View(FilmDetails);

        }
        [HttpPost]
        public async Task<IActionResult> Delete(film film)
        {
            var film1 = _content.Film.FirstOrDefault(d => d.Id == film.Id);
            if (film1 == null)
            {
                return View(film);
            }
            // supression de l'acteur
            _content.Film.Remove(film1);
            // enregistrement des informations de facon asynchrone avec la promesse await
            await _content.SaveChangesAsync();
            //return RedirectToAction("Index");
            return RedirectToAction(nameof(Index));
        }
        //#region methode creer avec verifiaction
        //[HttpPost]
        //public IActionResult Create([Bind("Nom", "photoProfil", "profil", "Biographie")] Acteurs acteur)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(acteur);
        //    }
        //    _content.Acteurs.Add(acteur);
        //    _content.SaveChanges();
        //    //return RedirectToAction("Index");

        //    return RedirectToAction(nameof(Index));
        //}
    }
}
