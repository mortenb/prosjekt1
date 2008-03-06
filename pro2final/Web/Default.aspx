<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Src="kategori.ascx" TagName="kat" TagPrefix="uc1" %>

<%@ Register Src="~/produkt.ascx" TagName="pro" TagPrefix="uc2" %>

<%@ Reference Control = "produkt.ascx" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     &nbsp;<uc1:kat ID="kategori" runat="server" ></uc1:kat>
     
     <uc2:pro ID="produkt" runat="server" />
    <br />
     <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
     &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
   
    
</asp:Content>   
