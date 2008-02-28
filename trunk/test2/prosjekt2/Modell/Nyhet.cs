using System;
using System.Collections.Generic;
using System.Text;

namespace Modell
{
    public class Nyhet
    {
        private int _nyhetsID;
        private string _tittel;
        private string _tekst;

        public Nyhet()
        {
            throw new System.NotImplementedException();
        }

        public int _nyhetsID
        {
            get
            {
                return _nyhetsID;
            }
            set
            {
                _nyhetsID = value;
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

        public string _tekst
        {
            get
            {
                return _tekst;
            }
            set
            {
                _tekst = value;
            }
        }
    }
}
