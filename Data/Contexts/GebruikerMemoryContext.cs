﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KillerApp.Data.Interfaces;
using KillerApp.Model;
using Model;

using static Model.Gebruiker;

namespace Data.Contexts
{
    public class GebruikerMemoryContext : IGebruikerContext
    {
        private List<Gebruiker> gebruikers = new List<Gebruiker>();
        private int gebruikerID = 1;
        public GebruikerMemoryContext()
        {
            if (gebruikers.Count == 0)
            {

                gebruikers.Add(new Gebruiker("Mautjee", "Mauro", "Eijsenring",
                    "mauro@eijsnering.com",gebruikerID++));
                gebruikers.Add(new Gebruiker( "Johnie", "John", "Doe",
                    "john@Doe.com", gebruikerID++));
            }
        }

        public QueryFeedback AddGebruiker(Gebruiker gebruiker)
        {
            QueryFeedback feedback = new QueryFeedback();
            //Gebruiker gebr = new Gebruiker(gebruikerID++,gebruiker.Gebruikersnaam,gebruiker.Wachtwoord,)
            return feedback;
        }

        public Gebruiker CheckLogin(Gebruiker gebruiker)
        {
            QueryFeedback Data = new QueryFeedback();
            Gebruiker g = new Gebruiker("Mautjee", "Mauro", "Eijsenring",
                    "mauro@eijsnering.com", gebruikerID++);
            g.SetWachtwoord("1234");

            if (gebruiker.Gebruikersnaam == g.Gebruikersnaam && gebruiker.Wachtwoord == g.Wachtwoord)
            {
                Data.Gelukt = true;
                return g;
            }
            else
            {
                Data.Gelukt = false;
                Data.Message = $"Verkeerde Gebruikersnaam of Wachtwoord wat je hebt ingevult is {gebruiker.Gebruikersnaam} en als wachtwoord {gebruiker.Wachtwoord} maaht het moet {g.Gebruikersnaam} en als ww {g.Wachtwoord}";
                return g;
            }
        }

        public List<Gebruiker> GetAllGebruikers()
        {
            return gebruikers;
        }

        public Gebruiker GetbyID(int id)
        {
             IEnumerable<Gebruiker> g = from Gebruiker in gebruikers
                            where Gebruiker.GebruikerID == id
                            select Gebruiker;
            return g.ToList()[0];
        }

        public QueryFeedback updateGebruiker(Gebruiker Ngebruiker)
        {
            throw new NotImplementedException();
        }

        public QueryFeedback VoegActifiteitToe(Activiteit activiteit)
        {
            throw new NotImplementedException();
        }
    }
}
