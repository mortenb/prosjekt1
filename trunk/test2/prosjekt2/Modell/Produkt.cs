using System;
using System.Collections.Generic;
using System.Text;

namespace Modell
{
    public class Produkt
    {
        private int _produktID;
        private string _tittel;
        private static int _antallPaaLager;
        private string _beskrivelse;
        private string _bildeURL;
        private int _pris;
        private int _produktkategoriID;

        public Produkt()
        {
            throw new System.NotImplementedException();
        }

        public int _produktID
        {
            get
            {
                return _produktID;
            }
            set
            {
                _produktID = value;
            }
        }

        public string _tittel
        {
            get
            {
                return _tittel;
            }
            set
            {
                _tittel = value;
            }
        }

       public static int _antallPaaLager
        {
            get
            {
                return _antallPaaLager;
            }
            set
            {
                _antallPaaLager = value;
            }
        }

        public string _beskrivelse
        {
            get
            {
                return _beskrivelse;
            }
            set
            {
                _beskrivelse = value;
            }
        }

        public string _bildeURL
        {
            get
            {
                return _bildeURL;
            }
            set
            {
                _bildeURL = value;
            }
        }

        public int _pris
        {
            get
            {
                return _pris;
            }
            set
            {
                _pris = value;
            }
        }

        public int _produktkategoriID
        {
            get
            {
                return _produktkategoriID;
            }
            set
            {
                _produktkategoriID = value;
            }
        }
    }
}
