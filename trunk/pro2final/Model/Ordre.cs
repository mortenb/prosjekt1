using System;
using System.Collections.Generic;
using System.Text;

namespace myApp.Model
{
    public class Ordre
    {
        private int _ordreID;
        private DateTime _ordreDato;
        private string _brukernavn;

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

        public string Brukernavn
        {
            get
            {
                return _brukernavn;
            }
            set
            {
                _brukernavn = value;
            }
        }


        
    }
}
