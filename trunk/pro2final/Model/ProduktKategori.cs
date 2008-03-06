using System;
using System.Collections.Generic;
using System.Text;

namespace myApp.Model
{
    public class Produktkategori
    {
        private int _produktkategoriID;
        private string _navn;

        public Produktkategori() { }

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

        public string Navn
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
