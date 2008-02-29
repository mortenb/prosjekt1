using System;
using System.Collections.Generic;
using System.Text;

namespace Prosjekt2.Modell
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

        public int ProduktID
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

        public string Tittel
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

       public static int AntallPaaLager
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

        public string Beskrivelse
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

        public string BildeURL
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

        public int Pris
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

        public int ProduktkategoriID
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
