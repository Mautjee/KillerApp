using System;
using System.Collections.Generic;
using System.Text;
using Model;
using KillerApp.Data.Repositories;
using KillerApp.Model;

namespace KillerApp.Logic
{
    public class StudentenhuisLogic : IStudentenhuisLogic
    {
        readonly StudentenhuisRepository _studentenhuisRepository;

        public StudentenhuisLogic(StudentenhuisRepository studenthuisRepo)
        {
            _studentenhuisRepository = studenthuisRepo;
        }

        public StudentenHuis GetallBewoners(int studenthuisId)
        {
            return _studentenhuisRepository.GetAllBewoners(studenthuisId);
        }

        public List<StudentenHuis> GetallStudentenhuizen()
        {
            List<StudentenHuis> liststudentenhuis = _studentenhuisRepository.GetallStudentenhuizen();
            StudentenHuis stuhuis = new StudentenHuis();

            if(liststudentenhuis[0].StudentenhuisID == 0) {
                liststudentenhuis.RemoveAt(0);
                return liststudentenhuis;
            }
            else
            {
                return liststudentenhuis ;
            }
            
        }

        public bool verwijderBewoner(Gebruiker gebruiker)
        {
            throw new NotImplementedException();
        }

        public StudentenHuis GetActiveStudentenhuisBijGebruiker(int gebruikerid)
        {
          return  _studentenhuisRepository.GetActiveStudentenhuisBijGebruiker(gebruikerid);
        }

        public List<Bewonersaldo> AlleactieveBewonersaldos(int studentenhuisId)
        {
            return _studentenhuisRepository.AlleactieveBewonersaldos(studentenhuisId);
        }

        public QueryFeedback voegBewonertoe(int gebruikerID, int studentenhuisID)
        {
            return _studentenhuisRepository.voegBewonertoe(gebruikerID,studentenhuisID);
        }

        public QueryFeedback MakeNewStudentenhuis(string naamniewestudentenhuis)
        {
            return _studentenhuisRepository.MakeNewStudentenhuis(naamniewestudentenhuis);
        }

        public List<Activiteit> GetListAtiviteitStudentenhuis(int studentnehuisID)
        {
            return _studentenhuisRepository.GetListAtiviteitStudentenhuis(studentnehuisID);
        }

        public Vraag GetVraagBijStudentenhuis(int studentenID)
        {
            return _studentenhuisRepository.GetVraagBijStudentenhuis(studentenID);
        }
    }
}
