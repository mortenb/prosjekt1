using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace myApp.Model
{
    public class Handlevogn 
    {
        private List<Ordrelinje> _handleliste;

        public Handlevogn() { _handleliste = new List<Ordrelinje>(); }

       

        public List<Ordrelinje> Handleliste
        {
            get { return _handleliste; }
            set { this._handleliste = value; }
        }

        public void slettHandleliste()
        {
            _handleliste = null;
        }

        public void leggTilVareIHandlevogn(Ordrelinje ol)
        {
            _handleliste.Add(ol);
        }

        public void slettVareFraHandlevogn(Ordrelinje ol)
        {
            foreach (Ordrelinje ordre in _handleliste)
            {
                if (ordre.ProduktID == ol.ProduktID)
                {
                    _handleliste.Remove(ordre);
                }
            }
        }
    }
} 
