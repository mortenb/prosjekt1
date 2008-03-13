<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Src="~/kategori.ascx" TagName="kat" TagPrefix="uc1" %>

<%@ Register Src="~/produkt.ascx" TagName="pro" TagPrefix="uc1" %>

<%@ Reference Control="~/produkt.ascx" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     &nbsp;<uc1:kat ID="kategori" runat="server" OnLoad="kategori_Load" ></uc1:kat>
     <div class="hovedinnhold">
     <uc1:pro ID="produkt" runat="server" />
     &nbsp; &nbsp;&nbsp; &nbsp;
     <asp:FormView ID="FormView1" runat="server">
     </asp:FormView>
    <br />
     <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
     &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
     
     <asp:Label ID="lblProduktID" runat="server" Visible="False"></asp:Label>
   </div>
    
</asp:Content>   
