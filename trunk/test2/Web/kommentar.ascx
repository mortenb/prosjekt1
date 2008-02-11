<%@ Control Language="C#" AutoEventWireup="true" CodeFile="kommentar.ascx.cs" Inherits="kommentar" %>
<asp:Panel CssClass="x-kommentar" ID="Panel1" runat="server" Height="254px" Width="530px" >

    <asp:Label ID="lblID" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="lblNivaa" runat="server" Text="" Visible="false"></asp:Label>
Tittel:
    <asp:TextBox ID="inputTittel" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="inputTittel"
        ErrorMessage="Tittel kan ikke være tom"></asp:RequiredFieldValidator><br />
    Forfatter:<asp:TextBox ID="inputForfatter" runat="server">Anonym Feiging</asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="inputForfatter"
        ErrorMessage="Forfatter må være fylt ut"></asp:RequiredFieldValidator><br />
    Tekst:<br />
    <asp:TextBox ID="inputTekst" runat="server" Height="139px"
        Width="284px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="inputTekst"
        ErrorMessage="Du må skrive noe i kommentaren!"></asp:RequiredFieldValidator><br />
    <asp:Button ID="btnLagre" runat="server" OnClick="btnLagre_Click" Text="Lagre" />
</asp:Panel>


