using System;
using System.Collections.Generic;
using KillerApp.Data.Repositories;
using KillerApp.Model;
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

        public Gebruiker CheckLogin(Gebruiker gebruiker)
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

        public QueryFeedback KokenVoorHuisgenoten(int[] mensen, Activiteit activiteit)
        {
            QueryFeedback feedback = new QueryFeedback();

            int aantalMensen = mensen.Length + 1;
            int bedragPerPersoon = activiteit.Bedrag / aantalMensen ;
            int aantalMeeEters = mensen.Length - 1;
            
            
            for(int i = 0; i <= aantalMeeEters; i++)
            {
                activiteit.Bedrag = bedragPerPersoon;
                activiteit.TegenGebruiker = mensen[i];
                feedback = _gebruikerRepo.VoegActifiteitToe(activiteit);
                if (!feedback.Gelukt)
                {
                    return feedback;
                }
            }
            

            return feedback;
        }

        public QueryFeedback updateGebruiker(Gebruiker gebruiker)
        {
            return _gebruikerRepo.updateGebruiker(gebruiker);
        }

        public QueryFeedback VoorschitenVoorHuisgenoten(int[] mensen, Activiteit activiteit)
        {
            QueryFeedback feedback = new QueryFeedback();

            int aantalPersonenVoorVoorschieten = mensen.Length - 1;

            for (int i = 0; i <= aantalPersonenVoorVoorschieten; i++)
            {
                activiteit.TegenGebruiker = mensen[i];

                feedback = _gebruikerRepo.VoegActifiteitToe(activiteit);
                if (!feedback.Gelukt)
                {
                    return feedback;
                }
            }

            return feedback;
        }
    }
}
