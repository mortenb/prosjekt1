using System;
using System.Collections.Generic;
using System.Text;
using myApp.Model;

namespace myApp.IDAL
{
    public interface IAnmeldelseDAL
    {
        List<Anmeldelse> getAnmeldelser(int produktID);

        Anmeldelse getAnmeldelse(int anmID);
    }
}
