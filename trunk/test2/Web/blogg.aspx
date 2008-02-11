<%@ Page Language="C#" AutoEventWireup="true" CodeFile="blogg.aspx.cs" Inherits="blogg" MasterPageFile="~/master.master" Title="Blogg" Trace="true"%>

<%@ MasterType TypeName="master" %>
<%@ Register TagPrefix="nyKommentar" TagName="nyKommentarBox" Src="~/kommentar.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"  >
    &nbsp; &nbsp; &nbsp; &nbsp;
    <table id="Table1" runat="server">
    </table>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
        <EmptyDataTemplate>
            Ingen innlegg<br />
        </EmptyDataTemplate>
        <Columns>
            <asp:BoundField DataField="tittel" />
            <asp:BoundField DataField="tekst" />
        </Columns>
    </asp:GridView>
    <asp:GridView ID="GridView2" runat="server">
    </asp:GridView>
    <nyKommentar:nyKommentarBox ID="nykommentar1" runat="server" Visible="false" EnableTheming="false" />
    
    
</asp:Content>