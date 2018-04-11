using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Recept
    {
        public int ReceptID { get; set; }

        public string Stappen { get; set; }

        public List<Ingredient> DeIngredienten { get; private set; }
    }
}
