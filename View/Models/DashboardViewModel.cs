using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KillerApp.Model;
using Model;

namespace KillerApp.View.Models
{
    public class DashboardViewModel
    {
        public Gebruiker gebruiker { get; set; }
        public StudentenHuis studentenhuis { get; set; }
        public Activiteit aciviteit { get; set; }
        public List<Bewonersaldo> Bewonersaldos { get; set; }


    }
}
