using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KillerApp.Model;
using Model;

namespace KillerApp.View.Models
{
    public class StudentenhuisDetailViewModel
    {
        public Gebruiker IngelogdeGebruiker { get; set; }
        public int SelectedStudentenhuisID { get; set; }
        public List<Bewonersaldo> VoornamenBewoners { get; set; }
        public Vraag DeToegangsvraag { get; set; }
    }
}
