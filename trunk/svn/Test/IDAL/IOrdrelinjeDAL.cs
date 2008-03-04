using System;
using System.Collections.Generic;
using System.Text;
using Prosjekt2.Modell;

namespace Prosjekt2.IDAL
{
    public interface IOrdrelinjeDAL
    {
        Ordrelinje getOrdrelinje(int ordrelinjeID);

        List<Ordrelinje> getOrdrelinjer(int ordreID);

        void slettOrdrelinje(int ordrelinjeID);

        void nyOrdrelinje(Ordrelinje ol);
    }
}
