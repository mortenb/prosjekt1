using System;
using System.Collections.Generic;
using System.Text;
using Prosjekt2.Modell;

namespace Prosjekt2.IBLL
{
    public interface IOrdreBLL
    {
        Ordre getOrdre(int ordreID);
        void nyOrdre(Ordre o);
    }
}
