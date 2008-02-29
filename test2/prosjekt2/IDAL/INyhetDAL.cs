using System;
using System.Collections.Generic;
using System.Text;
using Modell;

namespace IDAL
{
    public interface INyhetDAL
    {
        List<Nyhet> getNyheter();

        Nyhet getNyhet();

        void nyNyhet(Nyhet n);

        void endreNyhet(Nyhet n);

    }
}
