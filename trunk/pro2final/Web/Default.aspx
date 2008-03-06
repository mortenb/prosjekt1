<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Src="kategori.ascx" TagName="kat" TagPrefix="uc1" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    
    <uc1:kat ID="kategori" runat="server" ></uc1:kat>
   
    
</asp:Content>   
