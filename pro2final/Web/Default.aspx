<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Src="kategori.ascx" TagName="kat" TagPrefix="uc1" %>

<%@ Register Src="~/produkt.ascx" TagName="pro" TagPrefix="uc1" %>

<%@ Register Src="~/nyheter.ascx" TagName="ny" TagPrefix="uc1" %>

<%@ Reference Control = "produkt.ascx" %>

<%@ Reference Control = "nyheter.ascx" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     &nbsp;<uc1:kat ID="kategori" runat="server" OnLoad="kategori_Load" ></uc1:kat>
     <uc1:ny ID="nyheter" runat="server" ></uc1:ny>
     
     <uc1:pro ID="produkt" runat="server" />
     &nbsp; &nbsp;&nbsp;
    <br />
     <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
     &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
     
     <asp:Label ID="lblProduktID" runat="server" Visible="False"></asp:Label>
   
    
</asp:Content>   
