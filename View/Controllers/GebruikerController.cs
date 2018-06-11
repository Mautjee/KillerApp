﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Logic;
using Model;
using KillerApp.Factory;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

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
            Gebruiker gebr = gebruikLogic.GetbyID(id);
            return PartialView(gebr);
        }


        public IActionResult Toevoegen()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Post(string UserName, string Wachtwoord,string DeVoornaam,string DeAchternaam,
            string Email)
        {
            
            try
            {

                Gebruiker NiewGebruiker = new Gebruiker(UserName,DeVoornaam,DeAchternaam,Email);

                NiewGebruiker.SetWachtwoord(Wachtwoord);

                QueryFeedback feedback = gebruikLogic.AddGebruiker(NiewGebruiker);
                if (feedback.Gelukt)
                {
                    return RedirectToAction("index", "Home");
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
                return RedirectToAction("LogOut", "Home");
            }
            else { return Content(feedback.Message); }
        }

    }
}