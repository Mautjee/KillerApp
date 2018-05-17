﻿using System;
using System.Collections.Generic;
using KillerApp.Data.Repositories;
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

        public QueryFeedback AddGebruiker(Gebruiker gebruiker)
        {
            return _gebruikerRepo.AddGebruiker(gebruiker);
        }

        public QueryFeedback CheckLogin(Gebruiker gebruiker)
        {
            return _gebruikerRepo.CheckLogin(gebruiker);
        }

        public List<Gebruiker> GetAllGebruikers()
        {
           return  _gebruikerRepo.GetAllGebruikers();
        }

        public Gebruiker GetbyID(int id)
        {
            return _gebruikerRepo.GetbyID(id);
        }

        public QueryFeedback updateGebruiker(Gebruiker gebruiker)
        {
            return _gebruikerRepo.updateGebruiker(gebruiker);
        }
    }
}
