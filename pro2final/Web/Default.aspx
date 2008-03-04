<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="GridView_users" runat="server" />
    
        <table>
            <caption>Add user:</caption>
            <tr>
                <td>
                    Firstname:
                </td>
                <td>
                <asp:TextBox ID="TextBox_Firstname" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Lastname:
                </td>
                <td>
                <asp:TextBox ID="TextBox_Lastname" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Username(email):
                </td>
                <td>
                <asp:TextBox ID="TextBox_Username" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Password:
                </td>
                <td>
                    <asp:TextBox ID="TextBox_Password" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Button_Adduser" runat="server" OnClick="Button_Adduser_Click" Text="Create new user" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>

