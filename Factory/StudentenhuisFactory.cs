using System;
using System.Collections.Generic;
using System.Text;
using KillerApp.Data.Repositories;
using KillerApp.Logic;
using KillerApp.Data.Contexts;

namespace KillerApp.Factory
{
    public class StudentenhuisFactory
    {
        public static StudentenhuisLogic UseSqlContext()
        {
            return new StudentenhuisLogic(new StudentenhuisRepository(new StudentenHuisSqlContext()));
        }

        public static StudentenhuisLogic UseTestContext()
        {
            return new StudentenhuisLogic(new StudentenhuisRepository(new StudentenHuisMemoryContext()));
        }
    }
}
