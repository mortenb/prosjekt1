<%@ Page Language="C#" AutoEventWireup="true" CodeFile="blogg.aspx.cs" Inherits="blogg" MasterPageFile="~/master.master" Title="Blogg" ValidateRequest="false" %>

<%@ MasterType TypeName="master" %>
<%@ Register TagPrefix="nyKommentar" TagName="nyKommentarBox" Src="~/kommentar.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"  >
    <h3 runat="server"><asp:Label ID="Label1" Text="" runat="server"></asp:Label></h3>
    <table class="x-innlegg-tabell" id="Table1" runat="server" >

    </table>
    <nyKommentar:nyKommentarBox ID="nykommentar1" runat="server" Visible="false" EnableTheming="false" />
    
    
</asp:Content>