<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" Title="Innlogging" MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"  >

    <div>
        <asp:Login ID="Login1" DestinationPageUrl="~/Default.aspx" runat="server" FailureText="Innloggingen fielet. Vennligst prøv igjen." LoginButtonText="Logg inn" PasswordLabelText="Passord:" RememberMeText="Husk meg neste gang." TitleText="Innlogging" UserNameLabelText="Brukernavn:">
        </asp:Login>
        <asp:HyperLink ID="Registrer" runat="server" NavigateUrl="~/NyKunde.aspx">Ny kunde</asp:HyperLink><br />
    
    </div>
</asp:Content>