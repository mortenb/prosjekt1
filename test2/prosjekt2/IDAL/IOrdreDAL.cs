using System;
using System.Collections.Generic;
using System.Text;
using Modell;
namespace IDAL
{
    interface IOrdreDAL
    {
        void LeggTilOrdrelinje(OrdreLinje ol);
        Ordre getOrdre();
        void nyOrdre(Ordre o);
    }
}
