using System;

namespace KillerApp.Model
{
    public class Activiteit
    {
        public DateTime Datum { get; set; }
        public string Beschrijving { get; set; }
        public int Bedrag { get; set; }
        public int TegenGebruiker { get; set; }
        public int IngelogdeGebruiker { get; set; }
        public int StudentenhuisID { get; set; }

        public Activiteit(DateTime date,string beschrijving, int bedrag, int tegengerbuikerID,
            int ingelogdegebruiker, int studentenhuisid)
        {
            Datum = date;
            Beschrijving = beschrijving;
            Bedrag = bedrag;
            TegenGebruiker = tegengerbuikerID;
            IngelogdeGebruiker = ingelogdegebruiker;
            StudentenhuisID = studentenhuisid;
        }
    }
}