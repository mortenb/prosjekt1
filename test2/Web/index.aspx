﻿<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="index.aspx.cs" Inherits="_Default" Trace="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    Hvilken blogg vil du inn på?
    <asp:GridView ID="GridView_blogger" runat="server" AutoGenerateColumns="false">
        <Columns>
                <asp:HyperLinkField DataTextField="tittel" DataNavigateUrlFields="eier" DataNavigateUrlFormatString="~/blogg.aspx?blog={0}" />
            </Columns>
    </asp:GridView>
        &nbsp;
        
    </div>
    </form>
</body>
</html>
