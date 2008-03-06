using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Trenger en variabel som holder querystringen - den vil være en int

        //Trenger å sjekke om det er noe i querystringen

        //
    }


    protected void Page_VisVarerFraKategori()
    { //Denne metoden skal vise varer i tilhørende kategori
        //Skal dette opprettes som en dynamisk tabell slik som før?
        //Nei, vi prøver oss med en gridview og styler litt

    }

    protected void Page_VisTilbud()
    { //Denne metoden skal vise tilbud med en gang siden åpnes

    }
}
