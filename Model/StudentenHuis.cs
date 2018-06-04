using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class StudentenHuis
    {
        public int StudentenhuisID { get; set; }
        public string Naam { get; set; }
        public  List<Gebruiker> Bewoners { get; set; }
      
        public StudentenHuis()
        {
           
        }

        public bool VoegBewonerToe(Gebruiker gebruiker)
        {
            Bewoners.Add(gebruiker);
            return true;
        }
    }
}
