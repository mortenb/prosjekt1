<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="profil.aspx.cs" Inherits="profil" Title="Untitled Page" %>

<%@ Register Src="nyesteprodukt.ascx" TagName="nyesteprodukt" TagPrefix="uc2" %>

<%@ Register Src="~/profildata.ascx" TagName="prof" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server"> 
    <asp:WebPartManager ID="WebPartManager1" runat="server">
    </asp:WebPartManager>
    <br />
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
                        <asp:FormView title="Nyeste produkt" ID="FormView1" runat="server" DataSourceID="NyesteProduktLeverandoer">
                            <ItemTemplate>
                                AntallPaaLager:
                                <asp:Label ID="AntallPaaLagerLabel" runat="server" Text='<%# Bind("AntallPaaLager") %>'>
                                </asp:Label><br />
                                ProduktkategoriID:
                                <asp:Label ID="ProduktkategoriIDLabel" runat="server" Text='<%# Bind("ProduktkategoriID") %>'>
                                </asp:Label><br />
                                Tittel:
                                <asp:Label ID="TittelLabel" runat="server" Text='<%# Bind("Tittel") %>'></asp:Label><br />
                                Beskrivelse:
                                <asp:Label ID="BeskrivelseLabel" runat="server" Text='<%# Bind("Beskrivelse") %>'>
                                </asp:Label><br />
                                ProduktID:
                                <asp:Label ID="ProduktIDLabel" runat="server" Text='<%# Bind("ProduktID") %>'></asp:Label><br />
                                Pris:
                                <asp:Label ID="PrisLabel" runat="server" Text='<%# Bind("Pris") %>'></asp:Label><br />
                                BildeURL:
                                <asp:Label ID="BildeURLLabel" runat="server" Text='<%# Bind("BildeURL") %>'></asp:Label><br />
                            </ItemTemplate>                            
                        </asp:FormView>
                    </ZoneTemplate>
                    <CloseVerb Visible="False" />
                    <MinimizeVerb Text="Minimer" />
                    <RestoreVerb Text="Gjenopprett" />
                </asp:WebPartZone>
                <asp:Label ID="lblNyesteProduktID" runat="server" Visible="False"></asp:Label>
            </td>
            <td style="width: 100px" valign="top">
                <asp:WebPartZone ID="wpzKjoepteProdukter" runat="server">      
                     <ZoneTemplate>
                        <asp:GridView title="Kjøpte produkter" ID="GridView2" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            DataSourceID="ObjectDataSource1" DataKeyNames="ProduktID" EnableViewState="False" PageSize="5" OnSelectedIndexChanged="GridView2_Select" OnSelectedIndexChanging="GridView2_SelectedIndexChanging" >
                            
                            <Columns>
                                <asp:BoundField DataField="ProduktID" HeaderText="Varenummer" SortExpression="ProduktID" />
                                <asp:BoundField DataField="Tittel" HeaderText="Tittel" SortExpression="Tittel" />
                                <asp:BoundField DataField="Beskrivelse" HeaderText="Beskrivelse" SortExpression="Beskrivelse" />
                                <asp:HyperLinkField  DataTextField="ProduktID" DataNavigateUrlFields="ProduktID" DataNavigateUrlFormatString="~/profil.aspx?anm={0}" Text="Anmeld dette produktet" DataTextFormatString="Anmeld produkt" />
                            </Columns>
                            
                            <EmptyDataTemplate>
                                Du har ikke kjøpt noen varer.
                                <br />
                                <br />
                                Er du fattig eller?<br />
                                <br />
                                Få deg en jobb.<br />
                                <br />
                                Kjøp varer.<br />
                                <br />
                                Bli lykkelig.
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </ZoneTemplate>
                    <CloseVerb Visible="False" />
                    <MinimizeVerb Text="Minimer" />
                    <RestoreVerb Text="Gjenopprett" />                   
                </asp:WebPartZone>
                <asp:WebPartZone ID="wpzAnmeldProdukt" runat="server">
                    <CloseVerb Visible="False" />
                    <MinimizeVerb Enabled="False" Text="Minim" />
                    <RestoreVerb Enabled="False" />
                    <ZoneTemplate>
    <asp:Panel title="Anmeld produktet" ID="pnlAnmeld" runat="server" Height="231px" Visible="False" Width="251px">
        <asp:Label ID="lblAnmeldProduktID" runat="server" Height="18px" Width="95px" Visible="False"></asp:Label>
        <br />
        <asp:Label ID="lblAnmeldProduktTittel" runat="server"></asp:Label>
        <br />
        Tittel:<br />
        &nbsp;<asp:TextBox ID="tbAnmeldTittel" runat="server" OnTextChanged="tbAnmeldTittel_TextChanged" Width="240px"></asp:TextBox><br />
        Tekst:<br />
        <asp:TextBox ID="tbAnmeldTekst" runat="server"
            TextMode="MultiLine" OnTextChanged="tbAnmeldTekst_TextChanged" Height="138px" Width="240px"></asp:TextBox>
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
                    </ZoneTemplate>
                </asp:WebPartZone>
            </td>
        </tr>
    </table>
    &nbsp;&nbsp;<br />
    &nbsp;<br />
    Her kan du velge utseende på web-siden:<br />
    <table>
        <tr>        
             <td><asp:Button ID="Button2" runat="server" OnClick="Set_Theme" Text="Nice" /></td>
             <td><asp:Button ID="Button3" runat="server" OnClick="Set_Theme" Text="Green" /></td>
             <td><asp:Button ID="Button4" runat="server" OnClick="Set_Theme" Text="Matrix" /></td>
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
    <asp:ObjectDataSource ID="NyesteProduktLeverandoer" runat="server" SelectMethod="getProdukt"
        TypeName="myApp.BLL.ProduktBLL">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblNyesteProduktID" DefaultValue="0" Name="produktID"
                PropertyName="Text" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

