<%@ Control Language="C#" AutoEventWireup="true" CodeFile="produkt.ascx.cs" Inherits="produkt" %>
        <asp:Label ID="LabelLagtIHandlevogn" runat="server"></asp:Label><br />

<asp:FormView ID="FormView1" runat="server" DataSourceID="ProduktLeverandoer" Height="269px" Width="500px" >
    <ItemTemplate>
        <br />
        Beskrivelse:
        <asp:Label ID="BeskrivelseLabel" runat="server" Text='<%# Bind("Beskrivelse") %>'>
        </asp:Label><br />
        Varenummer:
        <asp:Label ID="ProduktIDLabel" runat="server" Text='<%# Bind("ProduktID") %>'></asp:Label><br />
        Pris:
        <asp:Label ID="PrisLabel" runat="server" Text='<%# Bind("Pris") %>'></asp:Label><br />
        AntallPaaLager:
        <asp:Label ID="AntallPaaLagerLabel" runat="server" Text='<%# Bind("AntallPaaLager") %>'>
        </asp:Label><br />
        <br />
        Antall du vil bestille:<br />        
        <asp:TextBox ID="tbAntall" runat="server" OnDataBinding="tbAntall_DataBinding" ></asp:TextBox><br />
        &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
            ControlToValidate="tbAntall" ErrorMessage="Du må taste inn et tall" OnDataBinding="RegularExpressionValidator1_DataBinding"
            ValidationExpression="\d+" Display="Static" ></asp:RegularExpressionValidator><br />
        <br />
        &nbsp;<br />
        <asp:Button ID="ButtonLeggTil" runat="server" OnCommand="btnLeggIHandlekurv_Click"
            OnDataBinding="btn_leggTil_DataBinding" Text="Legg til i handlekurv" /><br />
    </ItemTemplate>
    <HeaderTemplate>
        <br />
        Tittel:
        <asp:Label ID="TittelLabel" runat="server" Text='<%# Bind("Tittel") %>'></asp:Label><br />
    </HeaderTemplate>
    
</asp:FormView>
&nbsp;
<br />
<asp:DataList title="<-------- Tilbakemeldinger ----->" ID="DataList1" runat="server" DataSourceID="AnmeldelseLeverandoer" Width="500px" >
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
        &lt;-------- Tilbakemeldinger -------&gt;<br />
    </HeaderTemplate>
    <FooterTemplate>
        &lt;----------------------------------&gt;<br />
    </FooterTemplate>
</asp:DataList>
<asp:ObjectDataSource ID="AnmeldelseLeverandoer" runat="server" SelectMethod="getAnmeldelser"
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

