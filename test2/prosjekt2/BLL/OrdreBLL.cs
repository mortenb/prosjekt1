using System;
using System.Collections.Generic;
using System.Text;
using Prosjekt2.IDAL;
using Prosjekt2.IBLL;
using Prosjekt2.Modell;

namespace BLL
{
    public class OrdreBLL : IOrdreBLL
    {
        #region IOrdreBLL Members

        private IOrdreDAL ordreDAL = DALLoader.getOrdreDAL();

        public Ordre getOrdre(int ordreID)
        {
            Ordre ordre = ordreDAL.getOrdre(ordreID);
            return ordre;
            //throw new Exception("The method or operation is not implemented.");
        }

        public void nyOrdre(Ordre o)
        {
            ordreDAL.nyOrdre(o);
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
