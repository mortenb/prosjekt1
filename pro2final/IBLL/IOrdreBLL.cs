using System;
using System.Collections.Generic;
using System.Text;
using myApp.Model;

namespace myApp.IBLL
{
    public interface IOrdreBLL
    {
        Ordre getOrdre(int ordreID);
        int nyOrdre(Ordre o);
        void slettOrdre(int ordreID);
    }
}
