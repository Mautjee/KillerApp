using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Logic;
using Model;
using KillerApp.Factory;

namespace KillerApp.View.Controllers
{
    public class GebruikerController : Controller
    {
        GebruikerLogic gebruikLogic = GebruikersFactory.UseSqlContext();

        public IActionResult index()
        {   
            return View(gebruikLogic.GetAllGebruikers());
        }

        public IActionResult ViewDetailPartial(int id)
        {
            return PartialView(gebruikLogic.GetbyID(id));
        }


        public IActionResult Toevoegen()
        {
            return View();
        }

        public IActionResult Save()
        {
            return Content("Gelukt!");
        }

        [HttpPost]
        public ActionResult Post(string UserName, string Wachtwoord,string DeVoornaam,string DeAchternaam,
            string MobielNummer,string Email, DateTime Gebortendatum,Gebruiker.Geslacht Geslacht)
        {
            
            try
            {
                Gebruiker NiewGebruiker = new Gebruiker
                {
                    Gebruikersnaam = UserName,
                    Wachtwoord = Wachtwoord,
                    Voornaam = DeVoornaam,
                    Achternaam = DeAchternaam,
                    Mobielnummer = MobielNummer,
                    Email = Email,
                    Gebortendatum = Gebortendatum,
                    hetGeslacht = Geslacht

                };
                QueryFeedback feedback = gebruikLogic.AddGebruiker(NiewGebruiker);
                if (feedback.Gelukt)
                {
                    return RedirectToAction("index", "Gebruiker");
                }
                else { return Content(feedback.Message); }
                
            }
            catch(Exception ex)
            {
                return Content(ex.ToString());
            }
        }

        [HttpPost]
        public IActionResult UpdateGebruiker(Gebruiker gebr)
        {

            QueryFeedback feedback = gebruikLogic.updateGebruiker(gebr);
            if (feedback.Gelukt)
            {
                return RedirectToAction("index", "Gebruiker");
            }
            else { return Content(feedback.Message); }
        }
    }
}