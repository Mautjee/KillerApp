﻿using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace KillerApp.Data.Interfaces
{
    public interface IStudentenhuisContext
    {
        List<StudentenHuis> GetallStudentenhuizen();
        StudentenHuis GetallBewoners(int studenthuisId);
        bool voegBewonertoe(Gebruiker gebruiker);
        bool verwijderBewoner(Gebruiker gebruiker);
    }
}
