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
using KillerApp.Model;

namespace KillerApp.View.Controllers
{
    public class StudentenhuisController : Controller
    {
        StudentenhuisLogic studentenhuislogic = StudentenhuisFactory.UseSqlContext();
        StudentenhuisLogic studentenhuistest = StudentenhuisFactory.UseSqlContext();

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

            detailviewmodel.DeToegangsvraag = studentenhuislogic.GetVraagBijStudentenhuis(id);

            return PartialView(detailviewmodel);
        }

        public IActionResult ChangeStudentenhuis()
        {
            Gebruiker gebr = GetgebruikerfromSession();
            
            StudentenHuis stud = studentenhuislogic.GetActiveStudentenhuisBijGebruiker(gebr.GebruikerID);

            QueryFeedback unsubscribe = studentenhuislogic.UnsubscibeStudentenhuis(stud.StudentenhuisID,gebr.GebruikerID);
            if (unsubscribe.Gelukt)
            {
                return RedirectToAction("index", "Studentenhuis");
            }
            else
            {
                StudentenHuisViewModel studhuisviewmodel = new StudentenHuisViewModel();

                studhuisviewmodel.Ingelogdegebruiker = gebr;
                studhuisviewmodel.huidighuis = studentenhuislogic.GetActiveStudentenhuisBijGebruiker(gebr.GebruikerID);

                ModelState.AddModelError(string.Empty, "Je hebt nog een openstaant saldo zorg dat je dit aan iemand hebt afbetaald en ga verder");

                return View("Index",studhuisviewmodel);
                
            }
        }

        public IActionResult NiewStudentenhuis()
        {
            return PartialView();
        }

        // POST methods

        [HttpPost]
        public IActionResult VoegGebrAanStudhuisToe(int IngelogdeGebruiker, int studentenhuisid, string antwoord)
        {
            QueryFeedback Checkantwoord = studentenhuislogic.CheckAntwoordOpDeVraag(studentenhuisid, antwoord);

            if (Checkantwoord.Gelukt)
            {
                QueryFeedback feedback = studentenhuislogic.voegBewonertoe(IngelogdeGebruiker, studentenhuisid);

                if (feedback.Gelukt)
                {
                    return RedirectToAction("Dashboard", "Home");
                }
                else { return Content($"Het heeft niet gewerkt omdat: {feedback.Message}"); }
            }
            else { return Content(Checkantwoord.Message); }
            
        }

        [HttpPost]
        public IActionResult MakeNewStudentenhuis(string naamstudentenhuis, string devraag,string hetantwoord)
        {
            QueryFeedback feedback = studentenhuislogic.MakeNewStudentenhuis(naamstudentenhuis);

            Vraag niewevraagvoorhuis = new Vraag { DeVraag = devraag, Antwoord = hetantwoord };

            if (feedback.Gelukt)
            {

                StudentenHuis niewaangemaaktstudentenhuis = studentenhuislogic.GetStudentenhuisIdByStudentenhuisName(naamstudentenhuis);

                QueryFeedback feedback2 = studentenhuislogic.AddVraagBijStudentenhuis(niewaangemaaktstudentenhuis.StudentenhuisID, niewevraagvoorhuis);
                if (feedback2.Gelukt)
                {
                    return RedirectToAction("index", "Studentenhuis");
                }
                else {
                    return Content($"het toevoegen van de vraag is niet gelukt omdat {feedback2.Message}");
                }
                
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