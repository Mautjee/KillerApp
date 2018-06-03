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
        public string Wachtwoord
        {
            get { return _wachtwoord; }

            set { _wachtwoord = value; }
        }

        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public DateTime Geboortedatum { get; set; }
        public string Mobielnummer { get; set; }
        public Geslacht hetGeslacht { get; set; }
        public string Email { get; set; }

        public int StudentenhuisID { get; set; }


        public Gebruiker(string gebruikernaam, string voornaam,
            string achternaam, DateTime geboortedatum, string mobielnummer, Geslacht geslacht, string email, int gebruikerid = 0, int studentenhuisid = 0)
        {
            GebruikerID = gebruikerid;
            Gebruikersnaam = gebruikernaam;
            Voornaam = voornaam;
            Achternaam = achternaam;
            Geboortedatum = geboortedatum;
            Mobielnummer = mobielnummer;
            hetGeslacht = geslacht;
            Email = email;
            StudentenhuisID = studentenhuisid;
        }
        public Gebruiker()
        {
        }
        public Gebruiker(string gebruikersnaam,string wachtwoord)
        {
            Gebruikersnaam = gebruikersnaam;
            _wachtwoord = wachtwoord;
        }

        public void SetWachtwoord(string Setwachtwoord)
        {
            this._wachtwoord = Setwachtwoord;
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

   