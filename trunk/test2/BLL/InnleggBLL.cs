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

        public static void slettInnlegg(int innleggID, bool erEier)
        {
            //overridet metode
            if (erEier) //Eier av bloggen kan slette fullstendig..
            {
                slettInnlegg(innleggID);
            }
            else //Dersom en "tilfeldig" admin sletter, ikke slett, bare rediger.
            {
                endreTekst(innleggID, "Slettet av administrator");
            }
        }

        public static Innlegg getInnlegg(int innleggID)
        {
            return InnleggDAL.getInnlegg(innleggID);
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

        public static void redigerInnlegg(Innlegg innlegg)
        {
            InnleggDAL.redigerInnlegg(innlegg);
        }

    }
}
