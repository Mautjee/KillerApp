using System;
using System.Collections.Generic;
using Data.Repositories;
using Model;

namespace Logic
{
    public class GebruikerLogic : IGebruikerLogic
    {
        GebruikerRepository _gebruikerRepo;

        public GebruikerLogic(GebruikerRepository gebruikersrepo)
        {
            _gebruikerRepo = gebruikersrepo;
        }

        public List<Gebruiker> GetAllGebruikers()
        {
           return  _gebruikerRepo.GetAllGebruikers();
        }

        public bool LogtIn(string Gebruikersnaam, string Wachtwoord)
        {
            throw new NotImplementedException();
        }

        public bool MaaktNieuwStudentenuis(StudentenHuis studentenhuis)
        {
            throw new NotImplementedException();
        }
    }
}
