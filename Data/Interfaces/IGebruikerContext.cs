using System;
using System.Collections.Generic;
using System.Text;
using Model;


namespace KillerApp.Data.Interfaces
{
    public interface IGebruikerContext
    {
        List<Gebruiker> GetAllGebruikers();
        Gebruiker GetbyID(int id);
        QueryFeedback AddGebruiker(Gebruiker gebruiker);
        QueryFeedback updateGebruiker(Gebruiker gebruiker);
        Gebruiker CheckLogin(Gebruiker gebruiker);
    }
}
