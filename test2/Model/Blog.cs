using System;
using System.Collections.Generic;
using System.Text;

namespace DOTNETPROSJEKT1.Model
{
    public class Blog
    {
        public Blog() { }

        private int _blogID;
        public int BlogID
        {
            get { return _blogID; }
            set { _blogID = value; }
        }

        private string _tittel;
        public string Tittel
        {
            get { return _tittel; }
            set { _tittel = value; }
        }

        private string _eier;
        public string Eier
        {
            get { return _eier; }
            set { _eier = value; }
        }




    }
}
