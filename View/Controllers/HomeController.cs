using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using View.Models;
using Model;
using System.Security.Claims;
using Logic;
using KillerApp.Factory;
using KillerApp.Logic;
using KillerApp.Model;
using KillerApp.View.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.ApplicationInsights.Extensibility.Implementation;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace View.Controllers
{
    public class HomeController : Controller
    {
        GebruikerLogic gebruikLogic = GebruikersFactory.UseSqlContext();
        StudentenhuisLogic studentenhuislogic = StudentenhuisFactory.UseSqlContext();

        const string UserSession = "GerbuikerData";

        //Public Iaction Result

        public IActionResult Index(Gebruiker gebr)
        {
            return View(new Gebruiker());       
        }
        
        public IActionResult Dashboard()
        {
            if (!HttpContext.Session.Keys.Contains(UserSession))
            {
               return RedirectToAction("Index", "Home");
            }
            DashboardViewModel viewmodel = new DashboardViewModel();

            Gebruiker gebr = GetgebruikerfromSession();
            StudentenHuis studhuis = studentenhuislogic.GetActiveStudentenhuisBijGebruiker(gebr.GebruikerID);

            viewmodel.gebruiker = gebr;
            viewmodel.studentenhuis = studhuis;
            

            if (studhuis.Naam != "GeenHuis")
            {
                viewmodel.Bewonersaldos = studentenhuislogic.AlleactieveBewonersaldos(studhuis.StudentenhuisID);
                viewmodel.OverzichtActiviteit = studentenhuislogic.GetListAtiviteitStudentenhuis(studhuis.StudentenhuisID);
            }
            else
            {
                viewmodel.Bewonersaldos = new List<Bewonersaldo>();
            }
            

            return View(viewmodel);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
       
        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme).Wait();
            return RedirectToAction("Index", "Home");
        }

        

        //Post Methods

        [HttpPost]
        public IActionResult KokenStudentenhuis(int[] VoorGebr, DateTime DatumVanActiviteit,int VanGebruiker , string Beschrijving,
                                                string bedrag, int studentenhuisid, string KokenOfVoorschieten)
        {

            Activiteit activi = new Activiteit
            {
                Datum = DatumVanActiviteit,
                Beschrijving = Beschrijving,
                Bedrag = Convert.ToInt32(bedrag),
                StudentenhuisID = studentenhuisid,
                IngelogdeGebruiker = VanGebruiker
            };

            if (KokenOfVoorschieten == "koken")
            {
                QueryFeedback feedback = gebruikLogic.KokenVoorHuisgenoten(VoorGebr, activi);
                if (!feedback.Gelukt)
                {
                    RedirectToAction("Error", "Home");
                }
                return RedirectToAction("Dashboard", "Home");
            }
            else if (KokenOfVoorschieten == "voorgeschoten")
            {

                QueryFeedback VoegActiviteitToe = gebruikLogic.VoorschitenVoorHuisgenoten(VoorGebr,activi);
                if (VoegActiviteitToe.Gelukt)
                {
                    return RedirectToAction("Dashboard", "Home");
                }
                 return Content($"hetis niet gelukt omdat {VoegActiviteitToe.Message}");
                
            }
            else {
                return Content("Selecteet of je kookt of iets voorschiet");
            }
        }

        [HttpPost]
        public IActionResult CheckLogin(Gebruiker gebruiker)
        {
            
            var g = gebruikLogic.CheckLogin(gebruiker);

            HttpContext.Session.SetString(UserSession, JsonConvert.SerializeObject(g));

            if (g.GebruikerID > 0)
            {
                PerformLogin(gebruiker);

                if (HttpContext.Request.Query.ContainsKey("ReturnUrl"))
                {
                    return Redirect(HttpContext.Request.Query["ReturnUrl"]);
                }
                return RedirectToAction("Dashboard", "Home");
            }
            ModelState.AddModelError(string.Empty, "Verkeerde gebruikersnaam of wachtwoord");
            return View("index",new Gebruiker());
        }
        
        // Private methods

        private void PerformLogin(Gebruiker gebruiker)
        {
            
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, gebruiker.Gebruikersnaam)

            };

            var claimsIdentity = new ClaimsIdentity(claims,
                CookieAuthenticationDefaults.AuthenticationScheme);

            HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity)).Wait();
        }
        private Gebruiker GetgebruikerfromSession()
        {
            var accObject = HttpContext.Session.GetString(UserSession);

            Gebruiker gebr = new Gebruiker();
            if (accObject != null)
                gebr = JsonConvert.DeserializeObject<Gebruiker>(accObject);

            return gebr;
        }
    }
}
