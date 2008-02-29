using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class OrdreDAL : Prosjekt2.IDAL.IOrdreDAL
    {
        #region IOrdreDAL Members

        public void LeggTilOrdrelinje(Prosjekt2.Modell.OrdreLinje ol)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public Prosjekt2.Modell.Ordre getOrdre()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void nyOrdre(Prosjekt2.Modell.Ordre o)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
