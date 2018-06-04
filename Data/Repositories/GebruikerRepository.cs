using System;
using System.Collections.Generic;
using System.Text;
using KillerApp.Data.Interfaces;
using KillerApp.Data.Contexts;
using Model;
using KillerApp.Model;

namespace KillerApp.Data.Repositories
{
    public class GebruikerRepository : IGebruikerContext
    {
        readonly IGebruikerContext _gebruikerContext;

        public GebruikerRepository(IGebruikerContext gebruikercontext)
        {
            _gebruikerContext = gebruikercontext;
        }

        public QueryFeedback AddGebruiker(Gebruiker gebruiker)
        {
           return _gebruikerContext.AddGebruiker(gebruiker);
        }

        public Gebruiker CheckLogin(Gebruiker gebruiker)
        {
            return _gebruikerContext.CheckLogin(gebruiker);
        }

        public List<Gebruiker> GetAllGebruikers()
        {
            return _gebruikerContext.GetAllGebruikers();
        }


        public Gebruiker GetbyID(int id)
        {
            return _gebruikerContext.GetbyID(id);
        }

        public QueryFeedback updateGebruiker(Gebruiker gebruiker)
        {
            return _gebruikerContext.updateGebruiker(gebruiker);
        }

        public QueryFeedback VoegActifiteitToe(Activiteit activiteit)
        {
            return _gebruikerContext.VoegActifiteitToe(activiteit);
        }
    }
}
