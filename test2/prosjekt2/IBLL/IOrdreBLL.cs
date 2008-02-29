using System;
using System.Collections.Generic;
using System.Text;
using Modell;

namespace IBLL
{
    public interface IOrdreBLL
    {
        void LeggTilOrdrelinje(OrdreLinje ol);
        Ordre getOrdre();
        void nyOrdre(Ordre o);
    }
}
