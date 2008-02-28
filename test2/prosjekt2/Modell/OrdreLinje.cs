using System;
using System.Collections.Generic;
using System.Text;

namespace Modell
{
    public class OrdreLinje
    {
        private int _ordrelinjeID;
        private int _produktID;
        private int _antall;

        public OrdreLinje()
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
