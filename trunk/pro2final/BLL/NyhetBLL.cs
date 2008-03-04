using System;
using System.Collections.Generic;
using System.Text;
using myApp.IDAL;
using myApp.IBLL;
using myApp.Model;

namespace myApp.BLL
{
    public class NyhetBLL : INyhetBLL
    {
        #region INyhetBLL Members

        private INyhetDAL nyhetDAL = DALLoader.getNyhetDAL();

        public List<Nyhet> getNyheter()
        {
            List<Nyhet> nyheter = nyhetDAL.getNyheter();
            //throw new Exception("The method or operation is not implemented.");
            return nyheter;
        }

        public Nyhet getNyhet(int nyhetID)
        {
            Nyhet nyhet = nyhetDAL.getNyhet(nyhetID);
            //throw new Exception("The method or operation is not implemented.");
            return nyhet;
        }

        public void nyNyhet(Nyhet n)
        {
            nyhetDAL.nyNyhet(n);
            throw new Exception("The method or operation is not implemented.");
        }

        public void endreNyhet(Nyhet n)
        {
            nyhetDAL.endreNyhet(n);
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
