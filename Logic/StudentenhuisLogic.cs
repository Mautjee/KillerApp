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
            return _studentenhuisRepository.GetallStudentenhuizen();
        }

        public bool verwijderBewoner(Gebruiker gebruiker)
        {
            throw new NotImplementedException();
        }

        public int GetActiveStudentenhuisBijGebruiker(int id)
        {
          return  _studentenhuisRepository.GetActiveStudentenhuisBijGebruiker(id);
        }

        public List<Bewonersaldo> AlleactieveBewonersaldos(int studentenhuisId)
        {
            return _studentenhuisRepository.AlleactieveBewonersaldos(studentenhuisId);
        }

        public bool voegBewonertoe(Gebruiker gebruiker)
        {
            throw new NotImplementedException();
        }
    }
}
