using System;
using System.Collections.Generic;
using System.Text;
using myApp.Model;

namespace myApp.IDAL
{
    public interface IOrdreDAL
    {
        Ordre getOrdre(int ordreID);
        int nyOrdre(Ordre o);
        void slettOrdre(int ordreID);
    }
}
