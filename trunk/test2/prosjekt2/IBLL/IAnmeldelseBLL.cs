using System;
using System.Collections.Generic;
using System.Text;
using Modell;

namespace IBLL
{
    public interface IAnmeldelseBLL
    {
        List<Anmeldelse> getAnmeldelser(int produktID);
    }
}
