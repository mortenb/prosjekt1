<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="kasse.aspx.cs" Inherits="kasse" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:LoginView ID="LoginView1" runat="server">
        <LoggedInTemplate>
            Vennligst sjekk at dine data stemmer:<br />
            Navn:
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label><br />
            Adresse:
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label><br />
            Telefon:
            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label><br />
            Mail:
            <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label><br />
            <br />
            Velg betalingsform:<br />
            <br />
            Faktura<br />
            <asp:RadioButton ID="RadioButton1" runat="server" /><br />
            <br />
            Kredittkort<br />
            <asp:RadioButton ID="RadioButton2" runat="server" /><br />
            <br />
        </LoggedInTemplate>
        <AnonymousTemplate>
            Vennligst <a href="login.aspx">logg inn</a> for � gjennomf�re kj�pet.<br />
            <br />
            Ikke registrert?<br />
            <a href="NyKunde.aspx">Registrer deg &nbsp; &nbsp;</a> &nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp;
        </AnonymousTemplate>
    </asp:LoginView>
</asp:Content>

