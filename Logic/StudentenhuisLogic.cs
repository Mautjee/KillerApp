using System;
using System.Collections.Generic;
using System.Text;
using Model;
using KillerApp.Data.Repositories;

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

        public bool voegBewonertoe(Gebruiker gebruiker)
        {
            throw new NotImplementedException();
        }
    }
}
