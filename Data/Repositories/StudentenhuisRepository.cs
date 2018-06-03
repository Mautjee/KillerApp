﻿using System;
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

        public List<StudentenHuis> GetallStudentenhuizen()
        {
            throw new NotImplementedException();
        }

        public BewonerInfo GetStudentenHuisGebruiker(int id)
        {
            return _studenthuisContext.GetStudentenHuisGebruiker(id);
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