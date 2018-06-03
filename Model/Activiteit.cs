using System;

namespace KillerApp.Model
{
    public class Activiteit
    {
        public DateTime Date { get; set; }
        public string Beschrijving { get; set; }
        public int Bedrag { get; set; }

        public Activiteit(DateTime date,string beschrijving, int bedrag)
        {
            Date = date;
            Beschrijving = beschrijving;
            Bedrag = bedrag;
        }
    }
}