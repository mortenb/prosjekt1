using System;
using System.Collections.Generic;
using System.Text;
using myApp.Model;

namespace myApp.IBLL
{
    public interface IOrdrelinjeBLL
    {
        Ordrelinje getOrdrelinje(int ordrelinjeID);

        List<Ordrelinje> getOrdrelinjer(int ordreID);

        void slettOrdrelinje(int ordrelinjeID);

        void nyOrdrelinje(Ordrelinje ol);
    }
}