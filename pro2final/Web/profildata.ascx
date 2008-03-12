<%@ Control Language="C#" AutoEventWireup="true" CodeFile="profildata.ascx.cs" Inherits="profildata" %>
&nbsp;<table>
    <tr>
        <td>
                Fornavn:
        </td>
        <td>
            <asp:TextBox ID="TextBoxFornavn" runat="server" ValidationGroup="Kundedata"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="FNVal" runat="server" ControlToValidate="TextBoxFornavn" Display="Dynamic"
                ValidationGroup="Kundedata" ErrorMessage="Fornavn må oppgis">Obligatorisk</asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td>
                Etternavn
        </td>
        <td>
            <asp:TextBox ID="TextBoxEtternavn" runat="server" ValidationGroup="Kundedata"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="ENVal" runat="server" ControlToValidate="TextBoxEtternavn" Display="Dynamic"
                ErrorMessage="Etternavn m&#229; oppgis" ValidationGroup="Kundedata">Obligatorisk</asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td>
                Gateadresse
        </td>
        <td>
            <asp:TextBox ID="TextBoxAdresse" runat="server" ValidationGroup="Kundedata"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="AdresseVal" runat="server" ControlToValidate="TextBoxAdresse" ErrorMessage="Adresse må oppgis"
                ValidationGroup="Kundedata">Obligatorisk</asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td>
                Postnummer
        </td>
        <td>
            <asp:TextBox ID="TextBoxPostnummer" runat="server" ValidationGroup="Kundedata"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="PostnrVal" runat="server" ControlToValidate="TextBoxPostnummer" ErrorMessage="Postnummer må oppgis"
                ValidationGroup="Kundedata">Obligatorisk</asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td>
                Poststed</td>
        <td>
            <asp:TextBox ID="TextBoxPoststed" runat="server" ValidationGroup="Kundedata"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="PoststedVal" runat="server" ControlToValidate="TextBoxPoststed" ErrorMessage="Poststed må oppgis"
                ValidationGroup="Kundedata">Obligatorisk</asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td>
                Telefon</td>
        <td>
            <asp:TextBox ID="TextBoxTlf" runat="server"></asp:TextBox>
        </td>
    </tr>
</table>
    <asp:Label ID="lblOppdatert" runat="server" Text=""></asp:Label>
<br />
    
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Lagre" ValidationGroup="Kundedata" />