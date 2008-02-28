using System;
using System.Collections.Generic;
using System.Text;
using Modell;

namespace IBLL
{
    interface IAnmeldelseBLL
    {
        List<Anmeldelse> getAnmeldelser(int produktID);
    }
}
