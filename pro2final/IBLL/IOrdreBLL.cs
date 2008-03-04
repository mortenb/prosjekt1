using System;
using System.Collections.Generic;
using System.Text;
using myApp.Model;

namespace myApp.IBLL
{
    public interface IOrdreBLL
    {
        Ordre getOrdre(int ordreID);
        void nyOrdre(Ordre o);
        void slettOrdre(int ordreID);
    }
}
