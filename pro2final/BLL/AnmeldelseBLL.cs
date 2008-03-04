using System;
using System.Collections.Generic;
using System.Text;
using myApp.IDAL;
using myApp.IBLL;
using myApp.Model;

namespace myApp.BLL
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
