using System;
using System.Collections.Generic;
using System.Text;
using myApp.Model;

namespace myApp.IDAL
{
    public interface IOrdreDAL
    {
        Ordre getOrdre(int ordreID);
        void nyOrdre(Ordre o);
        void slettOrdre(int ordreID);
    }
}
