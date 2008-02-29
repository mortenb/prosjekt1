using System;
using System.Collections.Generic;
using System.Text;
using Modell;

namespace IDAL
{
    public interface IAnmeldelseDAL
    {
        List<Anmeldelse> getAnmeldelser(int produktID);
    }
}
