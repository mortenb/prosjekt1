<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="nyheter.aspx.cs" Inherits="nyheter" %>

<%@ Register Src="~/kategori.ascx" TagName="kat" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<uc1:kat ID="kategori" runat="server" />
    &nbsp;
    <asp:DataList ID="DataList1" runat="server" DataSourceID="ObjectDataSource1">
        <ItemTemplate>
            Tittel:
            <asp:Label ID="TittelLabel" runat="server" Text='<%# Eval("Tittel") %>'></asp:Label><br />
            Tekst:
            <asp:Label ID="TekstLabel" runat="server" Text='<%# Eval("Tekst") %>'></asp:Label><br />
            <br />
        </ItemTemplate>
    </asp:DataList>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="getNyheter"
        TypeName="myApp.BLL.NyhetBLL"></asp:ObjectDataSource>

</asp:Content>