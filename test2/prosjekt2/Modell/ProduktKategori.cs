using System;
using System.Collections.Generic;
using System.Text;

namespace Modell
{
    public class ProduktKategori
    {
        private int _produktkategoriID;
        private string _navn;

        public ProduktKategori()
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
