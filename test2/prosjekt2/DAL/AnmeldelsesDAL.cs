using System;
using System.Collections.Generic;
using System.Text;
using Prosjekt2.IDAL;

namespace Prosjekt2.DAL
{
    public class AnmeldelsesDAL : Prosjekt2.IDAL.IAnmeldelseDAL
    {
        #region IAnmeldelseDAL Members

        public List<Prosjekt2.Modell.Anmeldelse> getAnmeldelser(int produktID)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
