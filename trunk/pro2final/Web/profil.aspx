<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="profil.aspx.cs" Inherits="profil" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server"> 
    <asp:WebPartManager ID="WebPartManager1" runat="server">
    </asp:WebPartManager>
    &nbsp;
    <br />
    <table style="width: 349px; height: 90px">
        <tr>
            <td rowspan="3" style="width: 274px">
                <asp:WebPartZone ID="WebPartZone1" runat="server" HeaderText="Din Profil">
                    <ZoneTemplate>
                        <asp:Label ID="Label1" runat="server" Text="Profildata" Height="106px" Width="163px"></asp:Label>
                        <asp:TextBox ID="TextBox1" runat="server" Height="29px"></asp:TextBox>
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                        <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                    </ZoneTemplate>
                </asp:WebPartZone>
            </td>
            <td rowspan="3" style="width: 217px">
                <asp:WebPartZone ID="WebPartZone2" runat="server" HeaderText="Nye produkter">
                    <ZoneTemplate>
                        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                    </ZoneTemplate>
                </asp:WebPartZone>
            </td>
            <td rowspan="3" style="width: 391px">
                <asp:WebPartZone ID="WebPartZone3" runat="server" HeaderText="Anmeld produkt">
                    <ZoneTemplate>
                        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                    </ZoneTemplate>
                </asp:WebPartZone>
            </td>
        </tr>
        <tr>
        </tr>
        <tr>
        </tr>
    </table>
    <br />
 
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
    <asp:GridView ID="GridView1" runat="server" >
    </asp:GridView>
    <br />
    Her kan du velge utseende på web-siden:<br />
    <table>
        <tr>
            <td style="width: 161px">
                <asp:Button ID="Button2" runat="server" OnClick="Set_Theme" Text="Nice" />
                <asp:Button ID="Button3" runat="server" OnClick="Set_Theme" Text="Green" />
                <asp:Button ID="Button4" runat="server" OnClick="Set_Theme" Text="Matrix" /></td>
        </tr>
    </table>
    <br />
    
</asp:Content>

