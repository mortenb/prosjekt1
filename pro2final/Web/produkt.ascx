<%@ Control Language="C#" AutoEventWireup="true" CodeFile="produkt.ascx.cs" Inherits="produkt" %>

<asp:FormView ID="FormView1" runat="server" DataSourceID="ProduktLeverandoer" Height="269px" Width="260px" OnPageIndexChanging="FormView1_PageIndexChanging">
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
        Antall du vil bestille:<br />        
        <asp:TextBox ID="tbAntall" runat="server"></asp:TextBox><br />
        <br />
        <asp:LinkButton ID="btnLeggIHandlekurv" runat="server" OnClick="btnLeggIHandlekurv_Click">Legg til i handlekurv</asp:LinkButton>
    </ItemTemplate>
</asp:FormView>
<asp:DataList ID="DataList1" runat="server" DataSourceID="AnmeldelseLeverandoer">
    <ItemTemplate>
        <br />
        Tittel:
        <asp:Label ID="TittelLabel" runat="server" Text='<%# Eval("Tittel") %>'></asp:Label><br />
        Tekst:
        <asp:Label ID="TekstLabel" runat="server" Text='<%# Eval("Tekst") %>'></asp:Label><br />
        Karakter:
        <asp:Label ID="KarakterLabel" runat="server" Text='<%# Eval("Karakter") %>'></asp:Label><br />
        <br />
    </ItemTemplate>
    <HeaderTemplate>
        Tilbakemeldinger<br />
    </HeaderTemplate>
    <FooterTemplate>
        -----------------------------------<br />
    </FooterTemplate>
</asp:DataList><asp:ObjectDataSource ID="AnmeldelseLeverandoer" runat="server" SelectMethod="getAnmeldelser"
    TypeName="myApp.BLL.AnmeldelseBLL">
    <SelectParameters>
        <asp:ControlParameter ControlID="lblProduktID" Name="produktID" PropertyName="Text"
            Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>

<asp:Label ID="lblProduktID" runat="server" Visible="False"></asp:Label>
<asp:ObjectDataSource ID="ProduktLeverandoer" runat="server" SelectMethod="getProdukt" TypeName="myApp.BLL.ProduktBLL" >
    <SelectParameters>
        <asp:ControlParameter ControlID="lblProduktID" DefaultValue="0" Name="produktID"
            PropertyName="Text" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>

