<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="profil.aspx.cs" Inherits="profil" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    Her kan du endre dine personlige data<br />
    <br />
    <table style="width: 179px; height: 119px">
        <tr>
            <td>
                Fornavn:</td>
            <td style="width: 83px">
                <asp:TextBox ID="TextBoxFornavn" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                Etternavn</td>
            <td style="width: 83px">
                <asp:TextBox ID="TextBoxEtternavn" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                Gateadresse</td>
            <td style="width: 83px">
                <asp:TextBox ID="TextBoxAdresse" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                Postnummer</td>
            <td style="width: 83px">
                <asp:TextBox ID="TextBoxPostnummer" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                Poststed</td>
            <td style="width: 83px">
                <asp:TextBox ID="TextBoxPoststed" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                Telefon</td>
            <td style="width: 83px">
                <asp:TextBox ID="TextBoxTlf" runat="server"></asp:TextBox></td>
        </tr>
    </table>
    &nbsp;
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Lagre" /><br />
    <br />
    <asp:Label ID="LabelOppdatert" runat="server"></asp:Label><br />
    <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
    </asp:GridView>
    
</asp:Content>

