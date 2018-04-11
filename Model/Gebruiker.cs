using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace Model
{
    public class Gebruiker
    {

        public int GebruikerID { get; set; }

        public string Gebruikersnaam { get; set; }
        
        private string wachtwoord;
        public string Wachtwoord { get; set; }

        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public DateTime Gebortendatum { get; set; }
        public  int Mobielnummer { get; set; }
        public Geslacht Geslacht { get; set; }
        public string Email { get; set; }

        public int Studentenhuis { get; set; }

        public bool VernderWachtwoord(string nieuwwachtwoord)
        {

            this.wachtwoord = nieuwwachtwoord;
            return true;
        }

        public bool VoegStudentehuisToe(int StudenthuisID)
        {
            Studentenhuis = StudenthuisID;
            return true;
        }

    }
}

    public enum Geslacht
    {
        Man,Vrouw
    }