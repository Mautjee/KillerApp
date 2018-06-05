using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KillerApp.Model;
using Model;

namespace KillerApp.View.Models
{
    public class StudentenHuisViewModel
    {
        public Gebruiker Ingelogdegebruiker { get; set; }
        public List<StudentenHuis> allestudentenhuizen { get; set; }
    }
}
