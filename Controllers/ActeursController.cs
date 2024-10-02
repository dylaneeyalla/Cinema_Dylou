using GestionCinema.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TipamCinemaTicker.Datas;

namespace TipamCinemaTicker.Controllers
{
    public class ActeursController : Controller
    {
        private readonly AppDbContext _content;
        public ActeursController( AppDbContext Context)
        {
            _content = Context;
        }
        public  async Task<IActionResult> Index()
        {
            var data= await _content.Acteurs.ToListAsync();
            return View(data);
        }
        //Get:Acteurs/Create/1
        public IActionResult Create()
        {
            return View();
        }
        //[HttpPost]
        //public async Task<IActionResult> Create(Acteurs acteur)
        //{
        //    try
        //    {
        //        if (_content.Acteurs.Any(d => d.Id.Equals(acteur.Id)))
        //        {
        //            ViewBag.erreur = " Cet Acteur existe deja";
        //            return View(acteur);
        //        }
        //       _content.Acteurs.Add(acteur);
        //        await _content.SaveChangesAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        ViewBag.message = "Erreur : " + ex;
        //    }
        //    return RedirectToAction(nameof(Index));

        //    //return RedirectToAction("Index");
        //}

        // creer la methode pour gerer la vue details
        public IActionResult Details (int id)
        {
            var acteurDetails = _content.Acteurs.FirstOrDefault(acteur=> acteur.Id==id);
            if (acteurDetails == null) return View("NotFound");
            return View(acteurDetails);
        }
        //Get:Acteurs/Edit/1
        public IActionResult Edit(int id)
        {
            var acteursDetails = _content.Acteurs.FirstOrDefault(a => a.Id.Equals(id));
            if (acteursDetails == null)
            {
                return  View("NotFound");
            }
            return View(acteursDetails);
        }
        [HttpPost]
        public  async Task<IActionResult> Edit( Acteurs acteur)
        {
            var acteurs1 =_content.Acteurs.FirstOrDefault(d=>d.Id==acteur.Id);
          if(acteurs1==null)
            {
                return View(acteur);
            }
          // modification des informations contenu dans la base de donnee
            acteurs1.Nom = acteur.Nom;
            acteurs1.Biographie = acteur.Biographie;
            acteurs1.photoProfil = acteur.photoProfil;
           // enregistrement des informations de facon asynchrone avec la promesse await
           await  _content.SaveChangesAsync();
            //return RedirectToAction("Index");
            return RedirectToAction(nameof(Index));
        }
        //Get:Acteurs/Delete/1
        public IActionResult Delete(int id)
        {
            var acteursDetails = _content.Acteurs.FirstOrDefault(a => a.Id.Equals(id));
            if (acteursDetails == null)
            {
                return View("NotFound");
            }
            return View(acteursDetails);

        }
        [HttpPost]
        public async Task<IActionResult> Delete(Acteurs acteur)
        {
            var acteurs1 = _content.Acteurs.FirstOrDefault(d => d.Id == acteur.Id);
            if (acteurs1 == null)
            {
                return View(acteur);
            }
            // supression de l'acteur
            _content.Acteurs.Remove(acteurs1);
            // enregistrement des informations de facon asynchrone avec la promesse await
            await _content.SaveChangesAsync();
            //return RedirectToAction("Index");
            return RedirectToAction(nameof(Index));
        }
        #region methode creer avec verifiaction
        [HttpPost]
        public IActionResult Create([Bind("Nom", "photoProfil","profil", "Biographie")] Acteurs acteur)
        {
            if (!ModelState.IsValid)
            {
                return View(acteur);
            }
            _content.Acteurs.Add(acteur);
            _content.SaveChanges();
            //return RedirectToAction("Index");

            return RedirectToAction(nameof(Index));
        }
        #endregion

    }
}
