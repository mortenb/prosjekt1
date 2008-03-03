using System;
using System.Collections.Generic;
using System.Text;
using Prosjekt2.Modell;

namespace Prosjekt2.IDAL
{
    public interface INyhetDAL
    {
        List<Nyhet> getNyheter();

        Nyhet getNyhet(int nyhetID);

        void nyNyhet(Nyhet n);

        void endreNyhet(Nyhet n);

    }
}
