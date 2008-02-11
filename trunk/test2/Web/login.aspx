<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="Login" Title="Innlogging" MasterPageFile="~/master.master" %>

<%@ MasterType TypeName="master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"  >

    <div>
        <asp:Login ID="Login1" DestinationPageUrl="~/Index.aspx" runat="server" FailureText="Innloggingen fielet. Vennligst prøv igjen." LoginButtonText="Logg inn" PasswordLabelText="Passord:" RememberMeText="Husk meg neste gang." TitleText="Innlogging" UserNameLabelText="Brukernavn:">
        </asp:Login>
    
    </div>
</asp:Content>