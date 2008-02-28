using System;
using System.Collections.Generic;
using System.Text;

namespace Modell
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
    }
}
