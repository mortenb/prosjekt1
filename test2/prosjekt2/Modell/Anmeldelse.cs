using System;
using System.Collections.Generic;
using System.Text;

namespace Modell
{
    public class Anmeldelse : Nyhet
    {
        private int _anmeldelse;
        
        public Anmeldelse()
        {
            throw new System.NotImplementedException();
        }

        public int _anmeldelse
        {
            get
            {
                return _anmeldelse;
            }
            set
            {
                _anmeldelse = value;
            }
        }
    }
}
