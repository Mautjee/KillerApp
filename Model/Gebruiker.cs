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
    
        public string Email { get; set; }



        public Gebruiker(string gebruikernaam, string voornaam,
            string achternaam, string email, int gebruikerid = 0)
        {
            GebruikerID = gebruikerid;
            Gebruikersnaam = gebruikernaam;
            Voornaam = voornaam;
            Achternaam = achternaam;
           
            Email = email;

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

    }
}

   