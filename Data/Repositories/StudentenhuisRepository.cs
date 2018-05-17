using System;
using System.Collections.Generic;
using KillerApp.Data.Interfaces;
using KillerApp.Data.Contexts;
using Model;

namespace KillerApp.Data.Repositories
{
    public class StudentenhuisRepository : IStudentenhuisContext
    {
       readonly IStudentenhuisContext _StudenthuisContext;

        public StudentenhuisRepository(IStudentenhuisContext studentenhuiscontext)
        {
            _StudenthuisContext = studentenhuiscontext;
        }
        public StudentenHuis GetallBewoners(int studenthuisId)
        {
            return _StudenthuisContext.GetallBewoners(studenthuisId);
        }

        public List<StudentenHuis> GetallStudentenhuizen()
        {
            throw new NotImplementedException();
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
