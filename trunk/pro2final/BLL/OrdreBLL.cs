using System;
using System.Collections.Generic;
using System.Text;
using myApp.IDAL;
using myApp.IBLL;
using myApp.Model;

namespace myApp.BLL
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

        public void slettOrdre(int ordreID)
        {
            ordreDAL.slettOrdre(ordreID);
        }
        #endregion
    }
}
