﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KillerApp.Data.Interfaces;
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
                    Convert.ToDateTime("06-19-1997"), "0623947539", (Geslacht)0, "mauro@eijsnering.com",gebruikerID++));
                gebruikers.Add(new Gebruiker( "Johnie", "John", "Doe",
                   Convert.ToDateTime("07-9-1995"), "06347593404", (Geslacht)0, "john@Doe.com", gebruikerID++));
            }
        }

        public QueryFeedback AddGebruiker(Gebruiker gebruiker)
        {
            QueryFeedback feedback = new QueryFeedback();
            //Gebruiker gebr = new Gebruiker(gebruikerID++,gebruiker.Gebruikersnaam,gebruiker.Wachtwoord,)
            return feedback;
        }

        public QueryFeedback CheckLogin(Gebruiker gebruiker)
        {
            throw new NotImplementedException();
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
    }
}
