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
        public IActionResult Index(Gebruiker gebr)
        {
            return View(new Gebruiker());       
        }

        public IActionResult Dashboard()
        {
            if (!HttpContext.Session.Keys.Contains(UserSession))
            {
                RedirectToAction("Index", "Home");
            }
            DashboardViewModel viewmodel = new DashboardViewModel();

            Gebruiker gebr = GetgebruikerfromSession();
            StudentenHuis studhuis = studentenhuislogic.GetActiveStudentenhuisBijGebruiker(gebr.GebruikerID);

            viewmodel.gebruiker = gebr;
            viewmodel.studentenhuis = studhuis;

            if (studhuis.Naam != "GeenHuis")
            {
                viewmodel.Bewonersaldos = studentenhuislogic.AlleactieveBewonersaldos(studhuis.StudentenhuisID);
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

            return Content("Inlog Mislukt omdat");
        }

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
        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme).Wait();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult VoegActiviteitToe(DateTime DatumVanActiviteit,string Beschrijving,
                                                string Bedrag, int TegenGebruiker, int IngelogdeGebruiker,int studentenhuisid)
        {
            

            Activiteit activi = new Activiteit(DatumVanActiviteit,Beschrijving,Convert.ToInt32(Bedrag),TegenGebruiker,IngelogdeGebruiker, studentenhuisid);
            QueryFeedback feedback = gebruikLogic.VoegActifiteitToe(activi);
            if (feedback.Gelukt)
            {
                return RedirectToAction("Dashboard","Home");
            }
            else
            {
                return Content($"hetis niet gelukt omdat {feedback.Message}");
            }
            
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
