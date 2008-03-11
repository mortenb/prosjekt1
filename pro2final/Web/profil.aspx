<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="profil.aspx.cs" Inherits="profil" Title="Untitled Page" %>

<%@ Register Src="~/profildata.ascx" TagName="prof" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server"> 
    <asp:WebPartManager ID="WebPartManager1" runat="server">
    </asp:WebPartManager>
    <br />
    &nbsp;&nbsp;
    <table style="width: 100%; height: 100%">
        <tr>
            <td style="width: 100px" valign="top">
                <asp:WebPartZone ID="ProfilData" runat="server" HeaderText="Her kan du lagre profildata">
                    <ZoneTemplate>
                        <uc1:prof id="Prof1" runat="server">
                        </uc1:prof>
                    </ZoneTemplate>
                </asp:WebPartZone>
            </td>
            <td style="width: 100px" valign="top">
                <asp:WebPartZone ID="NyesteProdukter" runat="server" HeaderText="Nyeste produkter"
                    Width="241px">
                    <ZoneTemplate>
                        <asp:Label ID="Label2" runat="server" Height="253px" Text="Label" Width="3px"></asp:Label>
                    </ZoneTemplate>
                </asp:WebPartZone>
            </td>
            <td style="width: 100px" valign="top">
            </td>
        </tr>
    </table>
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
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Lagre" />
    <br />
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

