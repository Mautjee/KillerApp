using System;
using System.Collections.Generic;
using KillerApp.Data.Interfaces;
using KillerApp.Data.Contexts;
using Model;
using KillerApp.Model;

namespace KillerApp.Data.Repositories
{
    public class StudentenhuisRepository : IStudentenhuisContext
    {
       readonly IStudentenhuisContext _studenthuisContext;

        public StudentenhuisRepository(IStudentenhuisContext studentenhuiscontext)
        {
            _studenthuisContext = studentenhuiscontext;
        }
        public StudentenHuis GetAllBewoners(int studenthuisId)
        {
            return _studenthuisContext.GetAllBewoners(studenthuisId);
        }

        public List<Bewonersaldo> AlleactieveBewonersaldos(int studentenhuisId)
        {
            return _studenthuisContext.AlleactieveBewonersaldos(studentenhuisId);
        }

        public List<StudentenHuis> GetallStudentenhuizen()
        {
            return _studenthuisContext.GetallStudentenhuizen();
        }

        public StudentenHuis GetActiveStudentenhuisBijGebruiker(int gebruikerid)
        {
            return _studenthuisContext.GetActiveStudentenhuisBijGebruiker(gebruikerid);
        }

        public bool verwijderBewoner(Gebruiker gebruiker)
        {
            throw new NotImplementedException();
        }

        public QueryFeedback voegBewonertoe(int gebruikerID, int studentenhuisID)
        {
            return _studenthuisContext.voegBewonertoe(gebruikerID, studentenhuisID);
        }

        public QueryFeedback MakeNewStudentenhuis(string naamniewestudentenhuis)
        {
            return _studenthuisContext.MakeNewStudentenhuis(naamniewestudentenhuis);
        }

        public List<Activiteit> GetListAtiviteitStudentenhuis(int studentnehuisID)
        {
            return _studenthuisContext.GetListAtiviteitStudentenhuis(studentnehuisID);
        }

        public Vraag GetVraagBijStudentenhuis(int studentenID)
        {
            return _studenthuisContext.GetVraagBijStudentenhuis(studentenID);
        }

        public QueryFeedback AddVraagBijStudentenhuis(int studentenhuisID, Vraag devraag)
        {
            return _studenthuisContext.AddVraagBijStudentenhuis(studentenhuisID, devraag);
        }

        public StudentenHuis GetStudentenhuisIdByStudentenhuisName(string StudentenhuisName)
        {
            return _studenthuisContext.GetStudentenhuisIdByStudentenhuisName(StudentenhuisName);
        }

        public QueryFeedback CheckAntwoordOpDeVraag(int studenenthuisID, string hetAntwoord)
        {
            return _studenthuisContext.CheckAntwoordOpDeVraag(studenenthuisID,hetAntwoord);
        }
    }
}
