using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace DOTNETPROSJEKT1.Model
{
    public class Kommentar : Innlegg
    {
        public Kommentar() : base()
        { }

        private string _forfatter;
        public string Forfatter
        {
            get { return _forfatter; }
            set { _forfatter = value; }
        }

        private int _innleggID;
        public int InnleggID
        {
            get { return _innleggID; }
            set { _innleggID = value; }
        }

        
    }
}
