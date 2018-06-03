﻿using System;
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

namespace View.Controllers
{
    public class HomeController : Controller
    {
        GebruikerLogic gebruikLogic = GebruikersFactory.UseSqlContext();
        StudentenhuisLogic studentenhuislogic = StudentenhuisFactory.UseSqlContext();

        public IActionResult Index(Gebruiker gebr)
        {

            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Dashboard","home",gebr);
            }
            else
            {
                return View(new Gebruiker());
            }
        }

        public IActionResult Dashboard(Gebruiker gebr)
        {
            DashboardViewModel viewmodel = new DashboardViewModel();

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
            if (g.GebruikerID > 0)
            {
                PerformLogin(gebruiker);

                if (HttpContext.Request.Query.ContainsKey("ReturnUrl"))
                {
                    return Redirect(HttpContext.Request.Query["ReturnUrl"]);
                }
                return RedirectToAction("Index", "Home",g);
            }

            return Content("INlog MIslukt");
        }

        private void PerformLogin(Gebruiker gebruiker)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, gebruiker.Gebruikersnaam),
                new Claim("UserID", gebruiker.GebruikerID.ToString())

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
    }
}
