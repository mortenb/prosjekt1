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

    protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
    {
        string kunde = CreateUserWizard1.UserName.ToString();
        Roles.AddUserToRole(kunde, "kunde");
        MailAddress from = new MailAddress("webpro2gr1@gmail.com");
        MailAddress recipient = new MailAddress("webpro2gr1@gmail.com");
        MailMessage m = new MailMessage(from, recipient);
        m.Body = "Din konto er registrert!\n\nBrukernavn:"+
            kunde +"\nPassord: " +CreateUserWizard1.Password +
            "\n\nRegistrert e-postadresse: " +CreateUserWizard1.Email +
            "\n\nMed hilsen Webshopteamet.";
        m.Subject = "Registreringsbekreftelse";
 
        SmtpClient smc = new SmtpClient();
        smc.EnableSsl= true;
        smc.Send(m);
    }
}
