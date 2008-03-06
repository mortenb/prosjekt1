using System;
using System.Collections.Generic;
using System.Text;

namespace myApp.Model
{
    public class Ordre
    {
        private int _ordreID;
        private DateTime _ordreDato;
        

        public Ordre()
        {
            
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

        
    }
}
