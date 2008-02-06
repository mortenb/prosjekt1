<%@ Page Language="C#" MasterPageFile="~/master.master" AutoEventWireup="true" CodeFile="innlegg.aspx.cs" Inherits="innlegg" Title="Untitled Page" Trace="true"%>

<%@ MasterType TypeName="master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    &nbsp;
    
    <table id="Table1" runat="server" >
        <tbody>
        </tbody>
    </table>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Send endringer" />

</asp:Content>

