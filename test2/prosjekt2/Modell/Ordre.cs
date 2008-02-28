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
    
        public int _ordreID
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

        public DateTime _ordreDato
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

        public List<OrdreLinje> _listOrdreLinje
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
