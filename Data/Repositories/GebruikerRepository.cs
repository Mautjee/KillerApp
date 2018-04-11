    using System;
using System.Collections.Generic;
using System.Text;
using Data.Interfaces;
using Data.Contexts;
using Model;

namespace Data.Repositories
{
    public class GebruikerRepository
    {
        readonly IGebruikerContext _gebruikerContext;

        public GebruikerRepository(IGebruikerContext gebruikercontext)
        {
            _gebruikerContext = gebruikercontext;
        }


        public List<Gebruiker> GetAllGebruikers()
        {
            return _gebruikerContext.GetAllGebruiks();
        }
    }
}
