using System;
using System.Collections.Generic;
using System.Text;

namespace Prosjekt2.Modell
{
    public class Produktkategori
    {
        private int _produktkategoriID;
        private string _navn;

        public Produktkategori()
        {
            throw new System.NotImplementedException();
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

        private string Navn
        {
            get
            {
                return _navn;
            }
            set
            {
                _navn = value;
            }
        }
    }
}
