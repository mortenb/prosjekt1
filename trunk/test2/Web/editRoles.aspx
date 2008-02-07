<%@ Page Language="C#" AutoEventWireup="true" CodeFile="editRoles.aspx.cs" Inherits="editRoles" %>

<%@ Register Src="header.ascx" TagName="header" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>rediger roller</title>
</head>
<body>
    <form id="form1" runat="server">
   
        <uc1:header ID="Header1" runat="server" />
         <div>
        <br />
        <asp:Table ID="Table1" runat="server" Height="102px" Width="84px">
        
            <asp:TableRow runat="server">
                
                <asp:TableCell runat="server">
                <asp:ListBox ID="listUsers" runat="server" AutoPostBack="True" OnSelectedIndexChanged="oppdater" ></asp:ListBox>
                </asp:TableCell>
           
                <asp:TableCell runat="server">
                   Er admin: <asp:CheckBox ID="checkbox1" runat="server" AutoPostBack="True" OnCheckedChanged="toggleAdmin" />
                </asp:TableCell>
                
            </asp:TableRow>
               </asp:Table>
        &nbsp;
            <asp:Label ID="lblHendelse" runat="server" Text=""></asp:Label>
         
     
        </div>
    </form>
</body>
</html>
