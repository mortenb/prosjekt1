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
                        <uc1:prof title="Profildata" id="Prof1" runat="server" OnLoad="Prof1_Load">
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
                            DataSourceID="ObjectDataSource1">
                            <Columns>
                                <asp:BoundField DataField="ProduktID" HeaderText="Varenummer" SortExpression="ProduktID" />
                                <asp:BoundField DataField="Tittel" HeaderText="Tittel" SortExpression="Tittel" />
                                <asp:BoundField DataField="Beskrivelse" HeaderText="Beskrivelse" SortExpression="Beskrivelse" />
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
    <br />
    &nbsp;<asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False"
                            DataSourceID="ObjectDataSource1" OnSelectedIndexChanged="GridView3_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="AntallPaaLager" HeaderText="AntallPaaLager" SortExpression="AntallPaaLager" />
            <asp:BoundField DataField="ProduktkategoriID" HeaderText="ProduktkategoriID" SortExpression="ProduktkategoriID" />
            <asp:BoundField DataField="Tittel" HeaderText="Tittel" SortExpression="Tittel" />
            <asp:BoundField DataField="Beskrivelse" HeaderText="Beskrivelse" SortExpression="Beskrivelse" />
            <asp:BoundField DataField="ProduktID" HeaderText="ProduktID" SortExpression="ProduktID" />
            <asp:BoundField DataField="Pris" HeaderText="Pris" SortExpression="Pris" />
            <asp:BoundField DataField="BildeURL" HeaderText="BildeURL" SortExpression="BildeURL" />
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="getKjoepteProdukter"
                            TypeName="myApp.BLL.ProduktBLL" >
        <SelectParameters>
            <asp:ControlParameter ControlID="lblBrukernavn" DefaultValue="testfaen" Name="brukernavn"
                PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:Label ID="lblBrukernavn" runat="server" Visible="False"></asp:Label><br />
    
</asp:Content>

