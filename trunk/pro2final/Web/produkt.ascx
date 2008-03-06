<%@ Control Language="C#" AutoEventWireup="true" CodeFile="produkt.ascx.cs" Inherits="produkt" %>
<asp:FormView ID="FormView1" runat="server" DataSourceID="ProduktLeverandoer">
    <ItemTemplate>
        AntallPaaLager:
        <asp:Label ID="AntallPaaLagerLabel" runat="server" Text='<%# Bind("AntallPaaLager") %>'>
        </asp:Label><br />
        ProduktkategoriID:
        <asp:Label ID="ProduktkategoriIDLabel" runat="server" Text='<%# Bind("ProduktkategoriID") %>'>
        </asp:Label><br />
        Tittel:
        <asp:Label ID="TittelLabel" runat="server" Text='<%# Bind("Tittel") %>'></asp:Label><br />
        Beskrivelse:
        <asp:Label ID="BeskrivelseLabel" runat="server" Text='<%# Bind("Beskrivelse") %>'>
        </asp:Label><br />
        ProduktID:
        <asp:Label ID="ProduktIDLabel" runat="server" Text='<%# Bind("ProduktID") %>'></asp:Label><br />
        Pris:
        <asp:Label ID="PrisLabel" runat="server" Text='<%# Bind("Pris") %>'></asp:Label><br />
        BildeURL:
        <asp:Label ID="BildeURLLabel" runat="server" Text='<%# Bind("BildeURL") %>'></asp:Label><br />
        <br />
        Antall vil du bestille:<br />
        <asp:TextBox ID="tbAntall" runat="server"></asp:TextBox><br />
        <br />
        <asp:LinkButton ID="btnLeggIHandlekurv" runat="server" OnClick="btnLeggIHandlekurv_Click">Legg i handlekurv</asp:LinkButton><br />
    </ItemTemplate>
</asp:FormView>
<asp:Label ID="lblProduktID" runat="server" Visible="False"></asp:Label>
<asp:ObjectDataSource ID="ProduktLeverandoer" runat="server" SelectMethod="getProdukt" TypeName="myApp.BLL.ProduktBLL" >
    <SelectParameters>
        <asp:ControlParameter ControlID="lblProduktID" DefaultValue="0" Name="produktID"
            PropertyName="Text" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
