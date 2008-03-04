using System;
using System.Collections.Generic;
using System.Text;

namespace Prosjekt2.Modell
{
    public class Ordrelinje
    {
        private int _ordrelinjeID;
        private int _produktID;
        private int _antall;
        private int _ordreID;

        public Ordrelinje()
        {
            throw new System.NotImplementedException();
        }
    
        public int OrdrelinjeID
        {
            get
            {
                return _ordrelinjeID;
            }
            set
            {
                _ordrelinjeID = value;
            }
        }

        public int OrdreID
        {
            get
            {
                return _ordreID;
            }
            set
            {
                _ordreID = value;
            }
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

        public int Antall
        {
            get
            {
                return _antall;
            }
            set
            {
                _antall = value;
            }
        }
    }
}
