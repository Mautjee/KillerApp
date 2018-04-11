using System;
using System.Collections.Generic;
using System.Text;
using Data.Interfaces;
using Model;

namespace Data.Contexts
{
    public class GebruikerMemoryContext : IGebruikerContext
    {
        public List<Gebruiker> GetAllGebruikers()
        {
            List<Gebruiker> listGebruikers = new List<Gebruiker>()
            {
                /*
                new Gebruiker(1,"mautjee","1234","Mauro","Eijsenring",new DateTime(1997,06,19),0621659429,Geslacht.Man,"mauro@eijsenring.com",0),
                new Gebruiker(2,"johnie","1234","John","Doe",new DateTime(1998,05,19),0621653234,Geslacht.Man,"John@doe.com"),
                new Gebruiker(3,"Jane","1234","Jane","Doe",new DateTime(1993,06,19),0621653245,Geslacht.Vrouw,"Jane@Doe.com"),
                */
            };

            return listGebruikers;
        }
        public List<Gebruiker> GetAllGebruiks()
        {
            return GetAllGebruiks();
        }
    }
}
