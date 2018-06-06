using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KillerApp.Factory;
using KillerApp.Logic;
using KillerApp.Model;
using Model;

namespace KillerApp.View.Models
{
    public class StudentenHuisViewModel
    {
        StudentenhuisLogic studentenhuislogic = StudentenhuisFactory.UseSqlContext();

        public Gebruiker Ingelogdegebruiker { get; set; }
        public List<StudentenHuis> allestudentenhuizen { get; set; }
        public StudentenHuis huidighuis { get; set; }

        public bool checkLidVanStudentenhuis()
        {
            if (huidighuis.StudentenhuisID != 0) { return true; }
            else { return false; }
        }
    }
}
