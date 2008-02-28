using System;
using System.Collections.Generic;
using System.Text;

namespace Modell
{
    public class Ordre
    {
        private int _ordreID;
        private DateTime _ordreDato;
        private List<OrdreLinje> ordrelinjer;

        public Ordre()
        {
            throw new System.NotImplementedException();
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

        public DateTime OrdreDato
        {
            get
            {
                return _ordreDato;
            }
            set
            {
                _ordreDato = value;
            }
        }

        public List<OrdreLinje> ListOrdreLinje
        {
            get
            {
                return ordrelinjer;
            }
            set
            {
                ordrelinjer = value;
            }
        }
    }
}
