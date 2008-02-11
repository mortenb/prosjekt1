<%@ Page Language="C#" AutoEventWireup="true" CodeFile="editRoles.aspx.cs" Inherits="editRoles" MasterPageFile="~/master.master" Title="Rediger roller"  %>

<%@ MasterType TypeName="master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"  >   
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
</asp:Content>