using System;
using System.Collections.Generic;
using System.Text;
using Prosjekt2.Modell;

namespace Prosjekt2.IBLL
{
    public interface IAnmeldelseBLL
    {
        List<Anmeldelse> getAnmeldelser(int produktID);
    }
}
