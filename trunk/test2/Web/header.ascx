<%@ Control Language="C#" AutoEventWireup="true" CodeFile="header.ascx.cs" Inherits="header" %>
<asp:LoginStatus ID="LoginStatus1" runat="server" />
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
        <asp:RoleGroup Roles="blogger,admin">
            <ContentTemplate>
                &nbsp;<asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/index.aspx">Skriv nytt innlegg</asp:HyperLink>
            </ContentTemplate>
        </asp:RoleGroup>
    </RoleGroups>
</asp:LoginView>
&nbsp; &nbsp;&nbsp;&nbsp;
<br />
<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/index.aspx">Hjem</asp:HyperLink>
