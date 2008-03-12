<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="profil.aspx.cs" Inherits="profil" Title="Untitled Page" %>

<%@ Register Src="nyesteprodukt.ascx" TagName="nyesteprodukt" TagPrefix="uc2" %>

<%@ Register Src="~/profildata.ascx" TagName="prof" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server"> 
    <asp:WebPartManager ID="WebPartManager1" runat="server">
    </asp:WebPartManager>
    <br />
    &nbsp;&nbsp;
    <table style="width: 100%; height: 100%">
        <tr>
            <td style="width: 57px" valign="top">
                <asp:WebPartZone ID="wpzProfilData" runat="server" HeaderText="Her kan du lagre profildata">
                    <ZoneTemplate>
                        <uc1:prof title="Profildata" id="Prof1" runat="server" >
                        </uc1:prof>
                    </ZoneTemplate>
                    <CloseVerb Visible="False" />
                    <MinimizeVerb Text="Minimer" />
                    <RestoreVerb Text="Gjenopprett" />
                </asp:WebPartZone>
                &nbsp;
            </td>
            <td style="width: 55px" valign="top">
                <asp:WebPartZone ID="wpzNyesteProdukter" runat="server" HeaderText="Nyeste produkter"
                    Width="241px">
                    <ZoneTemplate>
                        <uc2:nyesteprodukt title="Nyeste produkt" ID="Nyesteprodukt1" runat="server" />
                    </ZoneTemplate>
                    <CloseVerb Visible="False" />
                    <MinimizeVerb Text="Minimer" />
                    <RestoreVerb Text="Gjenopprett" />
                </asp:WebPartZone>
            </td>
            <td style="width: 100px" valign="top">
                <asp:WebPartZone ID="wpzKjoepteProdukter" runat="server">      
                     <ZoneTemplate>
                        <asp:GridView title="Kjøpte produkter" ID="GridView2" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            DataSourceID="ObjectDataSource1" DataKeyNames="ProduktID" EnableViewState="False" PageSize="5" >
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" />
                                <asp:BoundField DataField="ProduktID" HeaderText="Varenummer" SortExpression="ProduktID" />
                                <asp:BoundField DataField="Tittel" HeaderText="Tittel" SortExpression="Tittel" />
                                <asp:BoundField DataField="Beskrivelse" HeaderText="Beskrivelse" SortExpression="Beskrivelse" />
                                <asp:ButtonField CommandName="btnAnmeld" Text="Anmeld dette produktet" />
                            </Columns>
                        </asp:GridView>
                    </ZoneTemplate>
                    <CloseVerb Visible="False" />
                    <MinimizeVerb Text="Minimer" />
                    <RestoreVerb Text="Gjenopprett" />                   
                </asp:WebPartZone>
            </td>
        </tr>
    </table>
    <asp:Panel ID="Panel1" runat="server" Height="231px" Visible="False" Width="251px">
        <asp:Label ID="lblAnmeldProduktID" runat="server" Height="18px" Width="95px"></asp:Label><br />
        Tittel:<br />
        &nbsp;<asp:TextBox ID="tbAnmeldTittel" runat="server"></asp:TextBox><br />
        Tekst:<br />
        <asp:TextBox ID="tbAnmeldTekst" runat="server"
            TextMode="MultiLine" OnTextChanged="tbAnmeldTekst_TextChanged"></asp:TextBox>
        <br />
        Karakter:<br />
        <asp:DropDownList ID="ddlAnmeldKarakter" runat="server">
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem>4</asp:ListItem>
            <asp:ListItem>5</asp:ListItem>
        </asp:DropDownList><br />
        <asp:LinkButton ID="lbAnmeldLeggTil" runat="server" Height="16px" Width="67px" OnClick="lbAnmeldLeggTil_Click">Legg til anmeldelse</asp:LinkButton>
        <br />
        <asp:Label ID="lblAnmeldOppdatert" runat="server"></asp:Label></asp:Panel>
    &nbsp;<br />
    &nbsp;<br />
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
    <br />
    
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="getKjoepteProdukter"
                            TypeName="myApp.BLL.ProduktBLL">
        <SelectParameters>
            <asp:ProfileParameter DefaultValue="0" Name="brukernavn" PropertyName="UserName"
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    
</asp:Content>

