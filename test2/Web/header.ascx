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
<br />
