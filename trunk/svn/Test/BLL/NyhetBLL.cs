using System;
using System.Collections.Generic;
using System.Text;
using Prosjekt2.IDAL;
using Prosjekt2.IBLL;
using Prosjekt2.Modell;

namespace BLL
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
