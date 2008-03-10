<%@ Control Language="C#" AutoEventWireup="true" CodeFile="nyheter.ascx.cs" Inherits="nyheter" %>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="NyhetsLeverandoer" AllowPaging="True">
    <Columns>
        <asp:BoundField DataField="Tittel" HeaderText="Tittel" SortExpression="Tittel" />
        <asp:BoundField DataField="Tekst" HeaderText="Tekst" SortExpression="Tekst" />
    </Columns>
</asp:GridView>
<asp:Label ID="lblSynlig" runat="server" Visible="False"></asp:Label>
<asp:ObjectDataSource ID="NyhetsLeverandoer" runat="server" SelectMethod="getNyheter"
    TypeName="myApp.BLL.NyhetBLL"></asp:ObjectDataSource>