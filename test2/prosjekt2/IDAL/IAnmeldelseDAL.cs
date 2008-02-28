using System;
using System.Collections.Generic;
using System.Text;
using Modell;
namespace IDAL
{
    interface IAnmeldelseDAL
    {
        List<Anmeldelse> getAnmeldelser(int produktID);
    }
}
