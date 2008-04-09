using System;
using System.Collections.Generic;
using System.Text;
using myApp.Model;
using myApp.IDAL;
namespace myApp.ClientDAL
{
    class OrdreDAL :IOrdreDAL
    {
        #region IOrdreBLL Members

        private WSOrdreDAL.OrdreDAL ordreDAL = new WSOrdreDAL.OrdreDAL();

        public Ordre getOrdre(int ordreID)
        {
            Ordre ordre = ordreDAL.getOrdre(ordreID);
            return ordre;
            //throw new Exception("The method or operation is not implemented.");
        }

        public int nyOrdre(Ordre o)
        {
            return ordreDAL.nyOrdre(o);

        }

        public void slettOrdre(int ordreID)
        {
            ordreDAL.slettOrdre(ordreID);
        }
        #endregion
    }
}
