using System;
using System.Collections.Generic;
using System.Text;
using myApp.Model;
//dette er en kommentar for å sjekke svn. MB :)
namespace myApp.IDAL
{
    public interface INyhetDAL
    {
        List<Nyhet> getNyheter();

        Nyhet getNyhet(int nyhetID);

        void nyNyhet(Nyhet n);

        void endreNyhet(Nyhet n);

    }
}
