using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KillerApp.Model;
using Model;
using KillerApp.Factory;
using Logic;

namespace KillerApp.View.Models
{
    public class DashboardViewModel
    {

        GebruikerLogic gebruikLogic = GebruikersFactory.UseSqlContext();

        public Gebruiker gebruiker { get; set; }
        public StudentenHuis studentenhuis { get; set; }
        public Activiteit aciviteit { get; set; }
        public List<Bewonersaldo> Bewonersaldos { get; set; }
        public List<Activiteit> OverzichtActiviteit { get; set; }

        public string GetNameVanGebruiker(int id)
        {
            Gebruiker gebr = gebruikLogic.GetbyID(id);
            if(gebr.Voornaam != null)
            {
                return gebr.Voornaam;
            }
            else { return "No Name"; }
        }

    }
}
