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

        const string Sessionname = "GerbuikerData";
        public IActionResult Index(Gebruiker gebr)
        {
            return View(new Gebruiker());       
        }

        public IActionResult Dashboard()
        {
            if (!HttpContext.Session.Keys.Contains(Sessionname))
            {
                RedirectToAction("Index", "Home");
            }
            DashboardViewModel viewmodel = new DashboardViewModel();

            Gebruiker gebr = GetgebruikerfromSession();

            viewmodel.gebruiker = gebr;
            viewmodel.studentenhuis = studentenhuislogic.GetActiveStudentenhuisBijGebruiker(gebr.GebruikerID);
            viewmodel.Bewonersaldos = studentenhuislogic.AlleactieveBewonersaldos(studentenhuislogic.GetActiveStudentenhuisBijGebruiker(gebr.GebruikerID).StudentenhuisID);

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

            HttpContext.Session.SetString(Sessionname, JsonConvert.SerializeObject(g));

            if (g.GebruikerID > 0)
            {
                PerformLogin(gebruiker);

                if (HttpContext.Request.Query.ContainsKey("ReturnUrl"))
                {
                    return Redirect(HttpContext.Request.Query["ReturnUrl"]);
                }
                return RedirectToAction("Dashboard", "Home");
            }

            return Content("INlog MIslukt");
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
            
            if (gebruikLogic.VoegActifiteitToe(activi).Gelukt)
            {
                return RedirectToAction("Dashboard","Home");
            }
            else
            {
                return Content("hetis niet gelukt");
            }
            
        }

        private Gebruiker GetgebruikerfromSession()
        {
            var accObject = HttpContext.Session.GetString(Sessionname);

            Gebruiker gebr = new Gebruiker();
            if (accObject != null)
                gebr = JsonConvert.DeserializeObject<Gebruiker>(accObject);

            return gebr;
        }
    }
}
