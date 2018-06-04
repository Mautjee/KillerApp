using System;
using System.Collections.Generic;
using System.Text;
using Data.Contexts;
using KillerApp.Data.Repositories;
using Logic;

namespace KillerApp.Factory
{
    public class GebruikersFactory
    {
        public static GebruikerLogic UseSqlContext()
        {
            return new GebruikerLogic(new GebruikerRepository(new GebruikerSqlContext()));
        }

        public static GebruikerLogic UseTestContext()
        {
            return new GebruikerLogic(new GebruikerRepository(new GebruikerMemoryContext()));
        }
    }
}
