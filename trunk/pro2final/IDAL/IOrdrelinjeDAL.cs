using System;
using System.Collections.Generic;
using System.Text;
using myApp.Model;

namespace myApp.IDAL
{
    public interface IOrdrelinjeDAL
    {
        Ordrelinje getOrdrelinje(int ordrelinjeID);

        List<Ordrelinje> getOrdrelinjer(int ordreID);

        void slettOrdrelinje(int ordrelinjeID);

        void nyOrdrelinje(Ordrelinje ol);

        List<Ordrelinje> getOrdrelinjerFraBrukernavn(string brukernavn);
    }
}
