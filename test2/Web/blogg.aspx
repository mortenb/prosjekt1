<%@ Page Language="C#" AutoEventWireup="true" CodeFile="blogg.aspx.cs" Inherits="blogg" MasterPageFile="~/master.master" Title="Blogg" Trace="true"%>

<%@ MasterType TypeName="master" %>
<%@ Register TagPrefix="nyKommentar" TagName="nyKommentarBox" Src="~/kommentar.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"  >
    &nbsp; &nbsp; &nbsp; &nbsp;
    <table class="x-innlegg-tabell" id="Table1" runat="server" >

    </table>
    <nyKommentar:nyKommentarBox ID="nykommentar1" runat="server" Visible="false" EnableTheming="false" />
    
    
</asp:Content>