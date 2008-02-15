<%@ Control Language="C#" AutoEventWireup="true" CodeFile="kommentar.ascx.cs" Inherits="kommentar" %>

<asp:Panel CssClass="x-redigerkommentar" ID="Panel1" runat="server" Height="254px" Width="530px" >

    <asp:Label ID="lblID" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="lblForeldreID" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="lblKommentarID" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="lblEier" runat="server" Text="" Visible="false"></asp:Label>
    <table id="Table1" runat="server">
       <tr>
            <td>Tittel:</td>
            <td><asp:TextBox ID="inputTittel" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
          <td>Forfatter:</td>
          <td><asp:TextBox ID="inputForfatter" runat="server" Text=""></asp:TextBox></td>
        </tr>
        <tr>
            <td>Tekst:</td>
        </tr>
        <tr>
            <td colspan="2"><asp:TextBox ID="inputTekst" runat="server" TextMode="MultiLine" CssClass="x-redigerkommentar-tekstboks"></asp:TextBox></td>
        </tr>   
    </table>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="inputTittel"
    ErrorMessage="Tittel kan ikke være tom"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="inputForfatter"
    ErrorMessage="Forfatter må være fylt ut"></asp:RequiredFieldValidator><br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="inputTekst"
        ErrorMessage="Du må skrive noe i kommentaren!"></asp:RequiredFieldValidator><br />
    <asp:Button ID="btnLagre" runat="server" OnClick="btnLagre_Click" Text="Lagre" />
    <asp:Button ID="Lukk" runat="server" OnClick="Lukk_Click" Text="Lukk" CausesValidation="false" /></asp:Panel>