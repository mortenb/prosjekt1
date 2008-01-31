using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace DOTNETPROSJEKT1.Model
{
    public class Innlegg
    {
        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _bloggID;
        public int BloggID
        {
            get { return _bloggID; }
            set { _bloggID = value; }
        }

        private string _tittel;
        public string Tittel
        {
            get { return _tittel; }
            set { _tittel = value; }
        }

        private DateTime _dato;
        public DateTime Dato
        {
            get { return _dato; }
            set { _dato = value; }
        }

        private string _tekst;
        public string Tekst
        {
            get { return _tekst; }
            set { _tekst = value; }
        }

        private string _forfatter;
        public string Forfatter
        {
            get { return _forfatter; }
            set { _forfatter = value; }
        }

    }
}
