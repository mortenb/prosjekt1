using System;
using System.Collections.Generic;
using System.Text;
using Prosjekt2.Modell;

namespace Prosjekt2.IBLL
{
    public interface IOrdreBLL
    {
        void LeggTilOrdrelinje(OrdreLinje ol);
        Ordre getOrdre();
        void nyOrdre(Ordre o);
    }
}
