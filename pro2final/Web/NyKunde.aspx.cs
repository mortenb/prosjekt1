using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net.Mail;

public partial class NyKunde : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    // Oppretter selve brukeren og legger data i databasen
    protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
    {
        string kunde = CreateUserWizard1.UserName.ToString();
        Roles.AddUserToRole(kunde, "kunde");
    }

    // Henter kundedata fra skjema og legger i brukerens profil
    protected void CreateUserWizard1_OpprettProfil(object sender, EventArgs e)
    {
        if (Profile.IsAnonymous == false)
        {
            Profile.fornavn =  this.TextBoxFornavn.Text;
            Profile.etternavn = this.TextBoxEtternavn.Text;
            Profile.gateadresse = this.TextBoxAdresse.Text;
            Profile.poststed = this.TextBoxPoststed.Text;
            Profile.postnummer = this.TextBoxPostnummer.Text;
            Profile.telefon = this.TextBoxTlf.Text;
            Profile.Theme = Page.Theme;
            Profile.Save();
            SendRegMail();
        }
    }

    // Sender mail med registreringsbekreftgelse.
    protected void SendRegMail()
    {
        SmtpClient smc = new SmtpClient();
        MailAddress from = new MailAddress("webpro2gr1@gmail.com");
        //MailAddress recipient = new MailAddress(CreateUserWizard1.Email.ToString());
        MailAddress recipient = new MailAddress("webpro2gr1@gmail.com");
        MailMessage m = new MailMessage(from, recipient);
        m.Body = "Din konto er registrert!\n\nBrukernavn:" +
            CreateUserWizard1.UserName.ToString() + 
            "\n\nRegistrert e-postadresse: " + CreateUserWizard1.Email +
            "\n\nRegistrerte personopplysninger:\nNavn: " + Profile.fornavn +
            " " + Profile.etternavn + "\nAdresse: " + Profile.gateadresse +
            "\nPostnr./-sted: " + Profile.postnummer + " " + Profile.poststed +
            "\nTelefonnr: " + Profile.telefon + "\n\nMed hilsen Webshopteamet.";
        m.Subject = "Registreringsbekreftelse";

        smc.EnableSsl = true;
        smc.Send(m);
    }
}
