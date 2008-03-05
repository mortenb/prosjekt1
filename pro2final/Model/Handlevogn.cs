using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace myApp.Model
{
    public class Handlevogn 
    {
        public Handlevogn() { }

        private List<Ordrelinje> _handleliste;

        public List<Ordrelinje> Handleliste
        {
            get { return _handleliste; }
            set { this._handleliste = value; }
        }
    }
} 
