using Model;
using System;
using System.Collections.Generic;
using System.Text;
using KillerApp.Model;

namespace KillerApp.Logic
{
    interface IStudentenhuisLogic
    {
        List<StudentenHuis> GetallStudentenhuizen();
        StudentenHuis GetallBewoners(int studenthuisId);
        QueryFeedback voegBewonertoe(int gebruikerID, int studentenhuisID);
        bool verwijderBewoner(Gebruiker gebruiker);
        StudentenHuis GetActiveStudentenhuisBijGebruiker(int gebruikerid);
        List<Bewonersaldo> AlleactieveBewonersaldos(int studentenhuisId);
        QueryFeedback MakeNewStudentenhuis(string naamniewestudentenhuis);
        List<Activiteit> GetListAtiviteitStudentenhuis(int studentnehuisID);
        Vraag GetVraagBijStudentenhuis(int studentenID);
        QueryFeedback AddVraagBijStudentenhuis(int studentenhuisID, Vraag devraag);
        StudentenHuis GetStudentenhuisIdByStudentenhuisName(string StudentenhuisName);
        QueryFeedback CheckAntwoordOpDeVraag(int studenenthuisID, string hetAntwoord);
        QueryFeedback UnsubscibeStudentenhuis(int studentenhuisID, int ingelogdeGebrID);
    }
}
