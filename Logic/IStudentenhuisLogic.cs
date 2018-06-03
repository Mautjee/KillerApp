﻿using Model;
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
        bool voegBewonertoe(Gebruiker gebruiker);
        bool verwijderBewoner(Gebruiker gebruiker);
        BewonerInfo GetStudentenHuisInfo(int id);
    }
}
