using System;
using System.Collections.Generic;
using System.Text;
using Prosjekt2.Modell;

namespace Prosjekt2.IDAL
{
    public interface IAnmeldelseDAL
    {
        List<Anmeldelse> getAnmeldelser(int produktID);
    }
}
