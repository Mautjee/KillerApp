using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace Logic
{
    interface IGebruikerLogic
    {
        bool LogtIn(string Gebruikersnaam, string Wachtwoord);
        bool MaaktNieuwStudentenuis(StudentenHuis studentenhuis);
        List<Gebruiker> GetAllGebruikers();
    }
}
