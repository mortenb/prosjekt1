<%@ Control Language="C#" AutoEventWireup="true" CodeFile="produktadmin.ascx.cs"
    Inherits="produktadmin" %>
<asp:Table ID="Table1" runat="server" Width="582px">
    <asp:TableRow runat="server">
        <asp:TableCell runat="server">
            Produktkategori:<br/>
            <asp:ListBox ID="PKListe" DataTextField="Navn" DataValueField="ProduktkategoriID"
                runat="server" AutoPostBack="True" OnSelectedIndexChanged="PKListe_SelectedIndexChanged">
            </asp:ListBox>
        </asp:TableCell>
        <asp:TableCell runat="server">
            Produkt:<br />
            <asp:ListBox ID="Produktliste" DataTextField="Tittel" DataValueField="ProduktID"
                runat="server" AutoPostBack="True" OnSelectedIndexChanged="Produktliste_SelectedIndexChanged"></asp:ListBox><br />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow runat="server">
        <asp:TableCell runat="server">
                Produktnavn
        </asp:TableCell>
        <asp:TableCell runat="server">
            <asp:TextBox ID="Tittel" runat="server" ValidationGroup="ObligFelt"></asp:TextBox>
            <asp:RequiredFieldValidator ID="TittelValidator" runat="server" ErrorMessage="Produktnavn m&#229; fylles ut"
                ValidationGroup="ObligFelt" ControlToValidate="Tittel"></asp:RequiredFieldValidator>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow runat="server">
        <asp:TableCell runat="server">Produktbeskrivelse:</asp:TableCell>
        <asp:TableCell runat="server">
            <asp:TextBox ID="Beskrivelse" TextMode="MultiLine" Rows="4" runat="server"></asp:TextBox>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow runat="server">
        <asp:TableCell runat="server">Pris:</asp:TableCell>
        <asp:TableCell runat="server">
            <asp:TextBox ID="Pris" runat="server" ValidationGroup="ObligFelt"></asp:TextBox>
            <asp:RequiredFieldValidator ID="PrisValidator" runat="server" ErrorMessage="Pris m&#229; fylles ut med heltall"
                ValidationGroup="ObligFelt" ControlToValidate="Pris"></asp:RequiredFieldValidator>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow runat="server">
        <asp:TableCell runat="server">Antall p� lager:</asp:TableCell>
        <asp:TableCell runat="server">
            <asp:TextBox ID="Lagerstatus" runat="server" ValidationGroup="ObligFelt"></asp:TextBox>
            <asp:RequiredFieldValidator ID="AntallValidator" runat="server" ErrorMessage="Antall p� lager m&#229; fylles ut med heltall"
                ValidationGroup="ObligFelt" ControlToValidate="Tittel"></asp:RequiredFieldValidator>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
<asp:Button ID="Send" runat="server" Text="Lagre produkt" ValidationGroup="ObligFelt" OnClick="Send_Click" />
