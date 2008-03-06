<%@ Control Language="C#" AutoEventWireup="true" CodeFile="kategori.ascx.cs" Inherits="kategori" %>
<asp:GridView CSSClass="x-grid-kat" ID="GridView1" runat="server" AutoGenerateColumns="false" ShowHeader="true" >
    <Columns>
        <asp:HyperLinkField  DataTextField="navn" DataNavigateUrlFields="id" DataNavigateUrlFormatString="~/Default.aspx?kat={0}" />
    </Columns>
</asp:GridView>
