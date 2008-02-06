using System;
using System.Collections.Generic;
using System.Text;

namespace DOTNETPROSJEKT1.Model
{
    public class Bruker
    {
        public Bruker() { }

        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _brukernavn;
        public string Brukernavn
        {
            get { return _brukernavn; }
            set { _brukernavn = value; }
        }

        private string _fornavn;
        public string Fornavn
        {
            get { return _fornavn; }
            set { _fornavn = value; }
        }

        private string _etternavn;
        public string Etternavn
        {
            get { return _etternavn; }
            set { _etternavn = value; }
        }
    }
}
