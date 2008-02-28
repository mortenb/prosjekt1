using System;
using System.Collections.Generic;
using System.Text;
using Modell;

namespace IDAL
{
    interface INyhetDAL
    {
        List<Nyhet> getNyheter();

        Nyhet getNyhet();

        void nyNyhet(Nyhet n);

        void endreNyhet(Nyhet n);

    }
}
