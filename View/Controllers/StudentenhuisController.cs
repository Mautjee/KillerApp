using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KillerApp.Factory;
using KillerApp.Logic;
using Model;
using KillerApp.View.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace KillerApp.View.Controllers
{
    public class StudentenhuisController : Controller
    {
        StudentenhuisLogic studentenhuislogic = StudentenhuisFactory.UseSqlContext();
        const string UserSession = "GerbuikerData";

        // Controller Methods
        public IActionResult Index()
        {
            StudentenHuisViewModel studhuisviewmodel = new StudentenHuisViewModel();
            Gebruiker gebr = GetgebruikerfromSession();

            studhuisviewmodel.allestudentenhuizen = studentenhuislogic.GetallStudentenhuizen();
            studhuisviewmodel.Ingelogdegebruiker = gebr;
            studhuisviewmodel.huidighuis = studentenhuislogic.GetActiveStudentenhuisBijGebruiker(gebr.GebruikerID);

            return View(studhuisviewmodel);
        }

        public IActionResult StudentenhuisPartial(int id)
        {
            StudentenhuisDetailViewModel detailviewmodel = new StudentenhuisDetailViewModel();

            detailviewmodel.IngelogdeGebruiker = GetgebruikerfromSession();
            detailviewmodel.VoornamenBewoners = studentenhuislogic.AlleactieveBewonersaldos(id);
            detailviewmodel.SelectedStudentenhuisID = id;

            return PartialView(detailviewmodel);
        }

        public IActionResult ChangeStudentenhuis()
        {


            return Content("Je bent geen lid meer");
        }

        public IActionResult NiewStudentenhuis()
        {
            return PartialView();
        }

        // POST methods

        [HttpPost]
        public IActionResult VoegGebrAanStudhuisToe(int IngelogdeGebruiker, int studentenhuisid)
        {
            QueryFeedback feedback = studentenhuislogic.voegBewonertoe(IngelogdeGebruiker, studentenhuisid);
            if (feedback.Gelukt)
            {
                return RedirectToAction("Dashboard", "Home");
            }
            return Content($"Het heeft niet gewerkt omdat: {feedback.Message}");
        }

        [HttpPost]
        public IActionResult MakeNewStudentenhuis(string naamstudentenhuis)
        {
            QueryFeedback feedback = studentenhuislogic.MakeNewStudentenhuis(naamstudentenhuis);
            if (feedback.Gelukt)
            {
                return RedirectToAction("index", "Studentenhuis");
            }
            else
            {
                return Content($"Het is niet gelukt omdat: {feedback.Message}");
            }
            
        }


        //private methods
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