using System;
using System.Collections.Generic;
using System.Text;

namespace Prosjekt2.Modell
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

        public int NyhetsID
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

        public string Tekst
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
