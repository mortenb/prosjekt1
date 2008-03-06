<%@ Control Language="C#" AutoEventWireup="true" CodeFile="kategori.ascx.cs" Inherits="kategori" %>
<div id="x-div-kat">
    <asp:GridView CSSClass="x-grid-kat" ID="GridView1" runat="server" AutoGenerateColumns="false" ShowHeader="true" >
        <Columns>
            <asp:HyperLinkField  DataTextField="Navn" DataNavigateUrlFields="ProduktkategoriID" DataNavigateUrlFormatString="~/Default.aspx?kat={0}" />
        </Columns>
    </asp:GridView>
</div>
    