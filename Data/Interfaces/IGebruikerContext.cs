using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace Data.Interfaces
{
    public interface IGebruikerContext
    {
        List<Gebruiker> GetAllGebruiks();
    }
}
