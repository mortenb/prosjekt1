using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class NyhetDAL : Prosjekt2.IDAL.INyhetDAL
    {
        #region INyhetDAL Members

        public List<Prosjekt2.Modell.Nyhet> getNyheter()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public Prosjekt2.Modell.Nyhet getNyhet()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void nyNyhet(Prosjekt2.Modell.Nyhet n)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void endreNyhet(Prosjekt2.Modell.Nyhet n)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
