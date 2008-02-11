<%@ Control Language="C#" AutoEventWireup="true" CodeFile="header.ascx.cs" Inherits="header" %>

<div id="divHeader1" class="x-header">
<asp:LoginStatus ID="LoginStatus1" runat="server" LoginText="Logg inn" LogoutText="Logg ut" />
<asp:LoginView ID="LoginView1" runat="server">
    <LoggedInTemplate>
        Velkommen &nbsp;<asp:LoginName ID="LoginName1" runat="server" />
    </LoggedInTemplate>
    <AnonymousTemplate>
        Du er ikke pålogget
    </AnonymousTemplate>
</asp:LoginView>
&nbsp;
<asp:LoginView ID="LoginView2" runat="server">
    <RoleGroups>
        <asp:RoleGroup Roles="blogger">
            <ContentTemplate>
                &nbsp;<asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/innlegg.aspx?=0">Skriv nytt innlegg</asp:HyperLink>
            </ContentTemplate>
        </asp:RoleGroup>
    </RoleGroups>
</asp:LoginView>
&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;<br />
<asp:LoginView ID="LoginView3" runat="server">
    <RoleGroups>
        <asp:RoleGroup Roles="admin">
            <ContentTemplate>
                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/admin.aspx">Administratorside</asp:HyperLink>
            </ContentTemplate>
        </asp:RoleGroup>
    </RoleGroups>
</asp:LoginView>
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
    &nbsp;&nbsp;

<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/index.aspx">Hjem</asp:HyperLink>
 <div id="divHeader2" class="x-header-logo">
    <asp:Label ID="lblLogo" Text="BLOGGERS" runat="server"  ></asp:Label>
</div>
</div>