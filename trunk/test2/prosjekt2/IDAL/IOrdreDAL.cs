using System;
using System.Collections.Generic;
using System.Text;
using Prosjekt2.Modell;

namespace Prosjekt2.IDAL
{
    public interface IOrdreDAL
    {
        void LeggTilOrdrelinje(OrdreLinje ol);
        Ordre getOrdre(int ordreID);
        void nyOrdre(Ordre o);
    }
}
