using System;
using System.Collections.Generic;
using System.Text;

using DOTNETPROSJEKT1.DAL;
using DOTNETPROSJEKT1.Model;

namespace DOTNETPROSJEKT1.BLL
{
    public static class InnleggBLL
    {
        public static void slettInnlegg(int innleggID)
        {
            InnleggDAL.slettInnlegg(innleggID);
        }

        public static Innlegg getInnlegg(int innleggID)
        {
            Innlegg i = new Innlegg();

            return i;
        }

        public static void endreTekst(int innleggID, string tekst)
        {
            InnleggDAL.endreTekst(innleggID, tekst);
        }

        public static List<Innlegg> getInnleggsListe(int bloggID)
        {
            List<Innlegg> l = InnleggDAL.getInnleggsListe(bloggID);

            return l;
        }

        public static void nyttInnlegg(Innlegg innlegg)
        {
            InnleggDAL.nyttInnlegg(innlegg);
        }

    }
}
