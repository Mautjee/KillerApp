using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KillerApp.Data.Interfaces;
using KillerApp.Model;
using Model;

namespace KillerApp.Data.Contexts
{
    public class StudentenHuisMemoryContext : IStudentenhuisContext
    {

        private List<StudentenHuis> AlleStudentenhuizen = new List<StudentenHuis>();
        private int StudentenhuisID = 1;
        private Gebruiker defaultBewoner = new Gebruiker();

        public StudentenHuisMemoryContext()
        {
            List<Gebruiker> LijstVanBewonersNios = new List<Gebruiker>();

            if (AlleStudentenhuizen.Count == 0)
            {
                AlleStudentenhuizen.Add(new StudentenHuis {StudentenhuisID = StudentenhuisID++, Naam = "HV NIOS", Bewoners = LijstVanBewonersNios });
                AlleStudentenhuizen.Add(new StudentenHuis { StudentenhuisID = StudentenhuisID++, Naam = "Asome Huis" });
            }
           
        }

        public List<Bewonersaldo> AlleactieveBewonersaldos(int studentenhuisId)
        {
            throw new NotImplementedException();
        }

        public StudentenHuis GetAllBewoners(int id)
        {
            throw new NotImplementedException();
        }

        public List<StudentenHuis> GetallStudentenhuizen()
        {
            throw new NotImplementedException();
        }

        public StudentenHuis GetActiveStudentenhuisBijGebruiker(int gebruikerid)
        {
           throw new NotImplementedException();
            
        }

        public bool verwijderBewoner(Gebruiker gebruiker)
        {
            throw new NotImplementedException();
        }

        public QueryFeedback voegBewonertoe(int gebruikerID, int studentenhuisID)
        {
            throw new NotImplementedException();
        }

        public QueryFeedback MakeNewStudentenhuis(string naamniewestudentenhuis)
        {
            throw new NotImplementedException();
        }

        public List<Activiteit> GetListAtiviteitStudentenhuis(int studentnehuisID)
        {
            throw new NotImplementedException();
        }

        public Vraag GetVraagBijStudentenhuis(int studentenID)
        {
            Vraag devraag = new Vraag
            {
                DeVraag = "wat is de hoofdstad van nederland",
                Antwoord = "Amsterdam"
            };

            return devraag;
        }
    }
}
