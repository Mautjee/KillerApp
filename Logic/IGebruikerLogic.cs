using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace Logic
{
    interface IGebruikerLogic
    {
        List<Gebruiker> GetAllGebruikers();
        Gebruiker GetbyID(int id);
        QueryFeedback AddGebruiker(Gebruiker gebruiker);
        QueryFeedback updateGebruiker(Gebruiker gebruiker);
        Gebruiker CheckLogin(Gebruiker gebruiker);
    }
}
