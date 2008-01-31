using System;
using System.Collections.Generic;
using System.Text;

using DOTNETPROSJEKT1.DAL;
using DOTNETPROSJEKT1.Model;

namespace DOTNETPROSJEKT1.BLL
{
    public static class BrukerBLL
    {
        public static List<Bruker> getBrukere()
        {
            List<Bruker> b = BrukerDAL.getBrukere();

            return b;
        }

        public static void login(string brukernavn, string pass)
        {
            BrukerDAL.login(brukernavn, pass);
        }

        public static Bruker getBruker(string brukernavn)
        {
            Bruker b = getBruker(brukernavn);

            return b;
        }

        public static Bruker nyBruker(Bruker bruker)
        {
            Console.WriteLine("BrukerBLL.nyBruker()");
            return BrukerDAL.nyBruker(bruker);
        }
    }
}
