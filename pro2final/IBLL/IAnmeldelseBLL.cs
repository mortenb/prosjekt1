using System;
using System.Collections.Generic;
using System.Text;
using myApp.Model;

namespace myApp.IBLL
{
    public interface IAnmeldelseBLL
    {
        List<Anmeldelse> getAnmeldelser(int produktID);

        Anmeldelse getAnmeldelse(int anmID);
    }
}
