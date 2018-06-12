using System;
using System.Collections.Generic;
using System.Text;
using KillerApp.Model;
using Model;

namespace KillerApp.Data.Interfaces
{
    public interface IStudentenhuisContext
    {
        List<StudentenHuis> GetallStudentenhuizen();
        StudentenHuis GetAllBewoners(int studenthuisId);
        List<Bewonersaldo> AlleactieveBewonersaldos(int studentenhuisId);
        QueryFeedback voegBewonertoe(int gebruikerID, int studentenhuisID);
        bool verwijderBewoner(Gebruiker gebruiker);
        StudentenHuis GetActiveStudentenhuisBijGebruiker(int gebrukerid);
        QueryFeedback MakeNewStudentenhuis(string naamniewestudentenhuis);
        List<Activiteit> GetListAtiviteitStudentenhuis(int studentenhuisID);
        Vraag GetVraagBijStudentenhuis(int studentenhuisID);
        QueryFeedback AddVraagBijStudentenhuis(int studentenhuisID, Vraag devraag);
        StudentenHuis GetStudentenhuisIdByStudentenhuisName(string StudentenhuisName);
        QueryFeedback CheckAntwoordOpDeVraag(int studenenthuisID, string hetAntwoord);
        Bewonersaldo CheckSaldo(int studentenhuisID,int ingelogdeGebrID);
        QueryFeedback UnsubscrbeStudentenhuis(int studentenhuisID, int gebruikerID);

    }
}
