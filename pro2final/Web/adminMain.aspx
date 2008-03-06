<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="adminMain.aspx.cs" Inherits="adminMain" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <a href="#Nyhet">Administrer varer</a>
    <br />
    <a href="#Kategori">Administrer kategorier</a>
    <br />
    <a href="#Vare">Administrer varer</a>
    <br />
    <asp:WebPartManager ID="WebPartManager1" runat="server">
    </asp:WebPartManager>
    <br />
    <asp:WebPartZone ID="Administrasjon" runat="server" MenuLabelText="Meny" TitleBarVerbButtonType="Link"
        PartChromeType="TitleAndBorder" Height="459px" Width="586px">
        <CloseVerb Enabled="False" Text="Lukk" Visible="False" />
        <ConnectVerb Text="Koble til" />
        <DeleteVerb Text="Slett" />
        <EditVerb Text="Rediger" />
        <ExportVerb Text="Eksporter" />
        <HelpVerb Text="Hjelp" />
        <MinimizeVerb Text="Minimer" />
        <RestoreVerb Text="Gjenopprett" />
        <ZoneTemplate>
            <asp:Panel ID="Nyheter" runat="server" title="Rediger nyheter">
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
            </asp:Panel>
            <asp:Panel ID="Kategorier" runat="server" title="Rediger kategorier" Height="151px"
                Width="300px" EnableViewState="False">
                <a name="Kategori"></a>
                <asp:TextBox ID="KatNavn" runat="server" CausesValidation="True" ValidationGroup="ValiderNy"></asp:TextBox>
                <asp:Button ID="Button1" runat="server" EnableViewState="False" OnClick="Button1_Click"
                    Text="Legg til kategori" ValidationGroup="ValiderNy" />
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="KatNavn"
                    ErrorMessage="Oppgi et nytt kategorinavn" Width="175px" ValidationGroup="ValiderNy"></asp:RequiredFieldValidator>
                &nbsp; &nbsp;<br />
                <asp:ListBox ID="KatListe" runat="server" AppendDataBoundItems="false" EnableViewState="False" Width="155px" AutoPostBack="true"></asp:ListBox>
                <asp:Button ID="SlettKat" runat="server" CausesValidation="False"
                    EnableViewState="False" Text="Slett Kategori" OnClick="SlettKat_Click" />
                &nbsp;
            </asp:Panel>
            <asp:Panel ID="Varer" runat="server" title="Rediger varer" Height="50px" Width="125px">
                <a name="Vare">Vareredigering kommer her</a>
            </asp:Panel>
        </ZoneTemplate>
    </asp:WebPartZone>
    &nbsp;
</asp:Content>
