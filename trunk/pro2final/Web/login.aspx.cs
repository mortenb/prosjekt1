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

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void PasswordRecovery1_SendingMail(object sender, MailMessageEventArgs e)
    {
        SmtpClient smtpClient = new SmtpClient();

        smtpClient.EnableSsl = true;
        e.Message.Body = "Vennligst naviger til webshoppen og logg deg inn med brukernavn og passordangitt under:\n\nBrukernavn: <% UserName %>\nPassord: <% Password %>";

        //For å slippe å sende masse tullemail rundt omkring, sender vi til oss selv:
        e.Message.To.Clear();
        e.Message.To.Add("webpro2gr1@gmail.com");

        smtpClient.Send(e.Message);

        e.Cancel = true;
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        PasswordRecovery1.Visible = true;
    }
}
