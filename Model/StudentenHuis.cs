using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class StudentenHuis
    {
        public int StudenthuisID { get; set; }
        public string Naam { get; set; }
        public  List<Gebruiker> Bewoners { get; set; }
      

    }
}
