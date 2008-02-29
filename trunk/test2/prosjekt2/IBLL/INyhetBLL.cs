using System;
using System.Collections.Generic;
using System.Text;
using Prosjekt2.Modell;

namespace Prosjekt2.IBLL
{
    public interface INyhetBLL
    {
        List<Nyhet> getNyheter();

        Nyhet getNyhet();

        void nyNyhet(Nyhet n);

        void endreNyhet(Nyhet n);
    }
}
