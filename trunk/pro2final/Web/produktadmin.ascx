<%@ Control Language="C#" AutoEventWireup="true" CodeFile="produktadmin.ascx.cs"
    Inherits="produktadmin" %>
<asp:Table CssClass="x-produktadmin" ID="Listetabell" runat="server">
    <asp:TableRow runat="server">
        <asp:TableCell CssClass="x-prodcelle" runat="server">
            Velg produktkategori:<br/>
            <asp:ListBox ID="PKListe" DataTextField="Navn" DataValueField="ProduktkategoriID"
                runat="server" AutoPostBack="True" OnSelectedIndexChanged="PKListe_SelectedIndexChanged" CausesValidation="false">
            </asp:ListBox>
        </asp:TableCell>
        <asp:TableCell CssClass="x-prodcelle" ID="ProdValg" Visible="false" runat="server">
            Velg produkt for endring:<br />
            <asp:ListBox ID="Produktliste" DataTextField="Tittel" DataValueField="ProduktID"
                runat="server" AutoPostBack="True" OnSelectedIndexChanged="Produktliste_SelectedIndexChanged"></asp:ListBox><br />
        </asp:TableCell>
    </asp:TableRow>
    </asp:Table>
    <asp:Table CssClass="x-produktadmin" ID="Produkttabell" visible="false" runat="server">
    <asp:TableRow runat="server">
        <asp:TableCell CssClass="x-prodcelle" runat="server">
                Produktnavn:
        </asp:TableCell>
        <asp:TableCell CssClass="x-prodcelle" runat="server">
            <asp:TextBox ID="Tittel" runat="server" ValidationGroup="ObligFelt" CausesValidation="true"></asp:TextBox>
            <asp:RequiredFieldValidator ID="TittelValidator" runat="server" ErrorMessage="Produktnavn m&#229; fylles ut"
                ValidationGroup="ObligFelt" ControlToValidate="Tittel"></asp:RequiredFieldValidator>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow runat="server">
        <asp:TableCell CssClass="x-prodcelle" runat="server">Produktbeskrivelse:</asp:TableCell>
        <asp:TableCell CssClass="x-prodcelle" runat="server">
            <asp:TextBox ID="Beskrivelse" TextMode="MultiLine" Rows="4" runat="server" CausesValidation="false"></asp:TextBox>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow runat="server">
        <asp:TableCell CssClass="x-prodcelle" runat="server">Pris:</asp:TableCell>
        <asp:TableCell CssClass="x-prodcelle" runat="server">
            <asp:TextBox ID="Pris" runat="server" ValidationGroup="ObligFelt" CausesValidation="true"></asp:TextBox><br />
            <asp:RequiredFieldValidator ID="PrisValidator" runat="server" ErrorMessage="Pris m&#229; fylles ut med heltall"
                ValidationGroup="ObligFelt" ControlToValidate="Pris"></asp:RequiredFieldValidator>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow runat="server">
        <asp:TableCell CssClass="x-prodcelle" runat="server">Antall på lager:</asp:TableCell>
        <asp:TableCell CssClass="x-prodcelle" runat="server">
            <asp:TextBox ID="Lagerstatus" runat="server" ValidationGroup="ObligFelt" CausesValidation="true"></asp:TextBox><br/>
            <asp:RequiredFieldValidator ID="AntallValidator" runat="server" ErrorMessage="Antall på lager m&#229; fylles ut med heltall"
                ValidationGroup="ObligFelt" ControlToValidate="Lagerstatus"></asp:RequiredFieldValidator>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
<asp:Button ID="Send" runat="server" Text="Lagre produkt" ValidationGroup="ObligFelt" OnClick="Send_Click" Visible="False" CausesValidation="true" />
