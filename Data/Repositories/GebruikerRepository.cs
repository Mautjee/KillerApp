    using System;
using System.Collections.Generic;
using System.Text;
using Data.Interfaces;
using Data.Contexts;
using Model;

namespace Data.Repositories
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
    }
}
