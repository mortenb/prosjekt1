using System;
using System.Collections.Generic;
using System.Text;

namespace myApp.Model
{
    public class Anmeldelse : Nyhet
    {
        private int _karakter;
        
        public Anmeldelse()
        {
            throw new System.NotImplementedException();
        }

        public int Karakter
        {
            get
            {
                return _karakter;
            }
            set
            {
                _karakter = value;
            }
        }

        private int _produktID;

        public int ProduktID
        {
            get { return _produktID; }
            set { this._produktID = value; }
        }
    }
}
