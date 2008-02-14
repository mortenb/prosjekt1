<%@ Page Language="C#" MasterPageFile="~/master.master" AutoEventWireup="true" CodeFile="innlegg.aspx.cs" Inherits="innlegg" Title="Skriv/rediger innlegg" ValidateRequest="false" %>

<%@ MasterType TypeName="master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    &nbsp;<asp:Label ID="Tittelledetekst" runat="server" Text="Tittel:"></asp:Label>
    &nbsp;<asp:TextBox ID="Tittelfelt" runat="server" Width="519px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Tittelfelt"
        ErrorMessage="Tittel må fylles ut"></asp:RequiredFieldValidator><br />
    &nbsp;<asp:Label ID="Datoledetekst" runat="server" Text="Tidspunkt:"></asp:Label>
    <asp:Label ID="Datofelt" runat="server"></asp:Label>
    <asp:Label ID="lblEier" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="LblInnleggID" runat="server" Visible="False"></asp:Label>
    <asp:TextBox ID="Innleggstekst" runat="server" Height="185px" TextMode="MultiLine" Width="737px"></asp:TextBox><br />
    
    <table id="Table1" runat="server" class="x-innleggstabell" >
        <tbody>
        </tbody>
    </table>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Send endringer" />

</asp:Content>

