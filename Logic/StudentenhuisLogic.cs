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

        public QueryFeedback AddVraagBijStudentenhuis(int studentenhuisID, Vraag devraag)
        {
            return _studentenhuisRepository.AddVraagBijStudentenhuis(studentenhuisID, devraag);
        }

        public StudentenHuis GetStudentenhuisIdByStudentenhuisName(string StudentenhuisName)
        {
            return _studentenhuisRepository.GetStudentenhuisIdByStudentenhuisName(StudentenhuisName);
        }

        public QueryFeedback CheckAntwoordOpDeVraag(int studenenthuisID, string hetAntwoord)
        {
            return _studentenhuisRepository.CheckAntwoordOpDeVraag(studenenthuisID, hetAntwoord);
        }

        public QueryFeedback UnsubscibeStudentenhuis(int studentenhuisID, int ingelogdeGebrID)
        {
            QueryFeedback feedback = new QueryFeedback();
           Bewonersaldo bewonersaldo = _studentenhuisRepository.CheckSaldo(studentenhuisID, ingelogdeGebrID);

            if(bewonersaldo != null)
            {
                if(bewonersaldo.Saldo >= 0)
                {
                   QueryFeedback unsubscibe = _studentenhuisRepository.UnsubscrbeStudentenhuis(studentenhuisID, ingelogdeGebrID);
                    if (unsubscibe.Gelukt)
                    {
                        feedback.Gelukt = true;
                        return feedback;
                    }
                    else
                    {
                        feedback.Gelukt = false;
                        feedback.Message = "er is iets fout gegaan bij het uitvoeren van de query voor het unsubscriben";
                        return feedback;
                    }
                    
                }
                else {
                    feedback.Gelukt = false;
                    feedback.Message = "Je hebt nog een schuld open staan";
                    return feedback;
                }
            }
            else
            {
                feedback.Gelukt = false;
                feedback.Message = "Er is iet fout gegaan met het uitoeren van de query";
                return feedback;
            }
        }
    }
}
