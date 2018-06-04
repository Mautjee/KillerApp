using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class QueryFeedback
    {
        public bool Gelukt { get; set; }
        public string Message { get; set; }

        public QueryFeedback(bool isgeluktofniet, string bericht)
        {
            Gelukt = isgeluktofniet;
            Message = bericht;
        }

        public QueryFeedback()
        {

        }
    }
}
