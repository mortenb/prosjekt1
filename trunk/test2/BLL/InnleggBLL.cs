using System;
using System.Collections.Generic;
using System.Text;

using DOTNETPROSJEKT1.DAL;
using DOTNETPROSJEKT1.Model;

namespace DOTNETPROSJEKT1.BLL
{
    public static class InnleggBLL
    {
        public static bool slettInnlegg(int innleggID)
        {
            return InnleggDAL.slettInnlegg(innleggID);
        }

        public static Innlegg getInnlegg(int innleggID)
        {
            Innlegg i = new Innlegg();

            return i;
        }

        public static bool endreTekst(int innleggID, string tekst)
        {
            InnleggDAL.endreTekst(innleggID, tekst);
            return false;
        }

        public static List<Innlegg> getInnleggsListe(Blog blogg)
        {
            List<Innlegg> l = InnleggDAL.getInnleggsListe(blogg);

            return l;
        }

    }
}
