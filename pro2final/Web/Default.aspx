<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Src="kategori.ascx" TagName="kat" TagPrefix="uc1" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    
    <uc1:kat ID="kategori" runat="server" ></uc1:kat>
     &nbsp; &nbsp;
     <asp:FormView ID="FormView1" runat="server" DataSourceID="ProduktLeverandoer">
         <ItemTemplate>
             Tittel:
             <asp:Label ID="TittelLabel" runat="server" Text='<%# Bind("Tittel") %>'></asp:Label><br />
             Beskrivelse:
             <asp:Label ID="BeskrivelseLabel" runat="server" Text='<%# Bind("Beskrivelse") %>'>
             </asp:Label><asp:Label ID="ProduktIDLabel" runat="server" Text='<%# Bind("ProduktID") %>'></asp:Label><br />
             Pris:
             <asp:Label ID="PrisLabel" runat="server" Text='<%# Bind("Pris") %>' Visible="False"></asp:Label><br />
             AntallPaaLager:
             <asp:Label ID="AntallPaaLagerLabel" runat="server" Text='<%# Bind("AntallPaaLager") %>'>
             </asp:Label><br />
             <br />
             Hvor mange vil du ha?<br />
             <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br />
             <br />
             <asp:LinkButton ID="btnBestillVare" runat="server" OnClick="btnBestillVare_Click">Legg i handlekurv</asp:LinkButton><br />
         </ItemTemplate>
     </asp:FormView>
     <asp:ObjectDataSource ID="ProduktLeverandoer" runat="server" SelectMethod="getProdukter"
         TypeName="myApp.BLL.ProduktBLL">
         <SelectParameters>
             <asp:QueryStringParameter DefaultValue="0" Name="produktkategoriID" QueryStringField="kat"
                 Type="Int32" />
         </SelectParameters>
     </asp:ObjectDataSource>
   
    
</asp:Content>   
