<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="adminMain.aspx.cs" Inherits="adminMain" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <a href="#Nyhet">Administrer varer</a>
    <br />
    <a href="#Noe">Administrer noe</a>
    <br />
    <a href="#NoeAnnet">Administrer noe annet</a>
    <br />
    <asp:WebPartManager ID="WebPartManager1" runat="server">
    </asp:WebPartManager>
    <br />
    <asp:WebPartZone ID="Administrasjon" runat="server" MenuLabelText="Meny" TitleBarVerbButtonType="Link" PartChromeType="TitleAndBorder" Height="459px" Width="586px">
        <CloseVerb Enabled="False" Text="Lukk" Visible="False" />
        <ConnectVerb Text="Koble til" />
        <DeleteVerb Text="Slett" />
        <EditVerb Text="Rediger" />
        <ExportVerb Text="Eksporter" />
        <HelpVerb Text="Hjelp" />
        <MinimizeVerb Text="Minimer" />
        <RestoreVerb Text="Gjenopprett" />
        <ZoneTemplate>
            <asp:panel ID="Nyheter" runat="server" title="Rediger nyheter">
                <a name="Nyhet"></a>
                <asp:Label ID="OverskriftLabel" runat="server">Overskrift</asp:Label>
                <br />
                <asp:TextBox ID="Overskrift" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="TekstLabel" runat="server">Tekst</asp:Label>
                <br />
                <asp:TextBox ID="Tekst" runat="server" TextMode="MultiLine"></asp:TextBox>
                <br />
                <asp:Button ID="Send" runat="server" Text="Send" />
            </asp:panel>
            <asp:Panel ID="Noe" runat="server" title="Rediger noe" Height="50px" Width="125px">
                <a name="Noe"></a>
                hey</asp:Panel>
             <asp:Panel ID="NoeAnnet" runat="server" title="Rediger noe annet" Height="50px" Width="125px">
                <a name="NoeAnnet"></a>
                hey</asp:Panel>
       </ZoneTemplate>
    </asp:WebPartZone>
    
</asp:Content>

