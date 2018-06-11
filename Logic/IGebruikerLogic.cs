using System;
using System.Collections.Generic;
using System.Text;
using Model;
using KillerApp.Model;

namespace Logic
{
    interface IGebruikerLogic
    {
        List<Gebruiker> GetAllGebruikers();
        Gebruiker GetbyID(int id);
        QueryFeedback AddGebruiker(Gebruiker gebruiker);
        QueryFeedback updateGebruiker(Gebruiker gebruiker);
        Gebruiker CheckLogin(Gebruiker gebruiker);
        QueryFeedback VoorschitenVoorHuisgenoten(int[] mensen,Activiteit activiteit);
        QueryFeedback KokenVoorHuisgenoten(int[] mensen, Activiteit activiteit);
    }
}
