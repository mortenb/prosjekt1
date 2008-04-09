using System;
using System.Collections.Generic;
using System.Text;
using myApp.ClientDAL.WSNyhetDAL;
using myApp.IDAL;
using myApp.Model;

namespace myApp.ClientDAL
{
    class NyhetDAL : INyhetDAL
    {
        private WSNyhetDAL.ServerNyhetDAL wsnDAL = new WSNyhetDAL.ServerNyhetDAL();

        public List<Nyhet> getNyheter()
        {
            List<Nyhet> nyheter = wsnDAL.getNyheter();
            //throw new Exception("The method or operation is not implemented.");
            return nyheter;
        }

        public Nyhet getNyhet(int nyhetID)
        {
            myApp.Model.Nyhet nyhet = wsnDAL.getNyhet(nyhetID);
            //throw new Exception("The method or operation is not implemented.");
            return nyhet;
        }

        public void nyNyhet(myApp.Model.Nyhet n)
        {
            wsnDAL.nyNyhet(n);
        }

        public void endreNyhet(myApp.Model.Nyhet n)
        {
            wsnDAL.endreNyhet(n);
            throw new Exception("The method or operation is not implemented.");
        }



    }
}
