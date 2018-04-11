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

        public IActionResult Gebruiker()
        {


            return View(gebruikLogic.GetAllGebruikers());
        }

        public IActionResult Toevoegen()
        {
            return View();
        }

        public IActionResult Save()
        {
            return Content("Gelukt!");
        }
    }
}