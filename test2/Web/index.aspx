<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="index.aspx.cs" Inherits="_Default" Trace="true" %>

<%@ Register Src="header.ascx" TagName="header" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:header ID="Header1" runat="server" OnLoad="Header1_Load" />
        <br />
    Hvilken blogg vil du inn på?&nbsp;
    <asp:GridView ID="GridView_blogger" runat="server" AutoGenerateColumns="false">
        <Columns>
                <asp:HyperLinkField DataTextField="tittel" DataNavigateUrlFields="eier" DataNavigateUrlFormatString="~/blogg.aspx?blog={0}" />
            </Columns>
    </asp:GridView>
        &nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Text="En enkelt blogg"></asp:Label>
        <asp:GridView ID="GridView_blogg" AutoGenerateColumns="false" runat="server">
        <Columns>
            <asp:BoundField DataField="tittel" SortExpression="true" HeaderText="Bloggen" />
        </Columns>
        </asp:GridView>
        
    </div>
    </form>
</body>
</html>
