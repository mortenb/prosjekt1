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
    
        public int _ordrelinjeID
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

        public int _produktID
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

        public int _antall
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
