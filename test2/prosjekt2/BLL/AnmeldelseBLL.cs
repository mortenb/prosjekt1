using System;
using System.Collections.Generic;
using System.Text;
using Prosjekt2.IDAL;
using Prosjekt2.IBLL;
using Prosjekt2.Modell;

namespace BLL
{
    public class AnmeldelseBLL : IAnmeldelseBLL
    {
        #region IAnmeldelseBLL Members

        private IAnmeldelseDAL anmeldelseDAL = DALLoader.getAnmeldelseDAL();

        public List<Anmeldelse> getAnmeldelser(int produktID)
        {
            List<Anmeldelse> anmeldelser = anmeldelseDAL.getAnmeldelser(produktID);
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
