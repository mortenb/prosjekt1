using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class AnmeldelseBLL : Prosjekt2.IBLL.IAnmeldelseBLL
    {
        #region IAnmeldelseBLL Members

        public List<Prosjekt2.Modell.Anmeldelse> getAnmeldelser(int produktID)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
