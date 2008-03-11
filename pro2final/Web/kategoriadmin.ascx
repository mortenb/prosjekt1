<%@ Control Language="C#" AutoEventWireup="true" CodeFile="kategoriadmin.ascx.cs"
    Inherits="kategoriadmin" %>
<div>
    &nbsp;
    <asp:Label ID="PkIDlabel" runat="server" Visible="False"></asp:Label><br />
    <asp:TextBox ID="KatNavn" runat="server" ValidationGroup="ValiderNy"
        OnTextChanged="KatNavn_TextChanged"></asp:TextBox>
    <asp:Button ID="RedigerKategori" runat="server" OnClientClick="Button1_Click" EnableViewState="False"
        OnClick="Button1_Click" Text="Legg til kategori" ValidationGroup="ValiderNy" />
    <br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="KatNavn"
        ErrorMessage="Oppgi et gyldig  kategorinavn  som ikke er i bruk" ValidationGroup="ValiderNy" Width="300px"></asp:RequiredFieldValidator>
    <br />
    <asp:ListBox ID="KatListe" runat="server" DataTextField="Navn" DataValueField="ProduktkategoriID"
        OnSelectedIndexChanged="KatListe_SelectedIndexChanged" Width="257px" AutoPostBack="True">
    </asp:ListBox>
    </div>
