<%@ Control Language="C#" AutoEventWireup="true" CodeFile="profildata.ascx.cs" Inherits="profildata" %>

<table style="width: 179px; height: 119px">
        <tr>
            <td>
                Fornavn:</td>
            <td style="width: 83px">
                <asp:TextBox ID="TextBoxFornavn" runat="server"></asp:TextBox></td>
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
    <asp:Label ID="lblOppdatert" runat="server" Text=""></asp:Label>
    
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Lagre" />