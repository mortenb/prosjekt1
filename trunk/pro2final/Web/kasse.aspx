<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="kasse.aspx.cs" Inherits="kasse" Title="Untitled Page" %>

<%@ Register Src="profildata.ascx" TagName="profildata" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:LoginView ID="LoginView1" runat="server" >
        <LoggedInTemplate>
            Vennligst sjekk at dine data stemmer:<br />
            &nbsp;<uc1:profildata ID="Profildata1" runat="server" />
            <br />
            Velg betalingsform:<br />
            <br />
            <asp:RadioButton ID="RadioButton1" runat="server" Checked="True" GroupName="betaling" Text="Faktura" /><br />
            <br />
            <asp:RadioButton ID="RadioButton2" runat="server" GroupName="betaling" Text="Postoppkrav" /><br />
            <br />
            <asp:Button ID="Button_kjop" runat="server" OnClick="Button_kjop_Click" Text="Bekreft kjøp" /><br />
        </LoggedInTemplate>
        <AnonymousTemplate>
            Vennligst <a href="login.aspx">logg inn</a> for å gjennomføre kjøpet.<br />
            <br />
            Ikke registrert?<br />
            <a href="NyKunde.aspx">Registrer deg &nbsp; &nbsp;</a> &nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp;
        </AnonymousTemplate>
    </asp:LoginView>
    <asp:Label ID="LabelFeil" runat="server"></asp:Label>
</asp:Content>

