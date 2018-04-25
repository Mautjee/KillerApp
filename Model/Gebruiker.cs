using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace Model
{
    public class Gebruiker
    {

        public int GebruikerID { get; set; }

        public string Gebruikersnaam { get; set; }

        private string _wachtwoord;
        public string Wachtwoord { get; set; }

        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public DateTime Gebortendatum { get; set; }
        public String Mobielnummer { get; set; }
        public Geslacht hetGeslacht { get; set; }
        public string Email { get; set; }

        public int StudentenhuisID { get; set; }


        public Gebruiker(int gebruikerid, string gebruikernaam, string wachtwoord, string voornaam,
            string achternaam, DateTime geboortedatum, string mobielnummer, Geslacht geslacht, string email){
            GebruikerID = gebruikerid;
            Gebruikersnaam = gebruikernaam;
            _wachtwoord = wachtwoord;
            Voornaam = voornaam;
            Achternaam = achternaam;
            Gebortendatum = geboortedatum;
            Mobielnummer = mobielnummer;
            hetGeslacht = geslacht;
            Email = email;
        }
        public Gebruiker()
        {
        }


        public bool VernderWachtwoord(string nieuwwachtwoord)
        {

            this._wachtwoord = nieuwwachtwoord;
            return true;
        }

        public bool VoegStudentehuisToe(int StudenthuisID)
        {
            StudentenhuisID = StudenthuisID;
            return true;
        }
        public enum Geslacht
        {
            Man,Vrouw
        }
    }
}

   