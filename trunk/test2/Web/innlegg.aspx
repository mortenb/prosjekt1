<%@ Page Language="C#" MasterPageFile="~/master.master" AutoEventWireup="true" CodeFile="innlegg.aspx.cs" Inherits="innlegg" Title="Skriv/rediger innlegg" Trace="true"%>

<%@ MasterType TypeName="master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="Tittelledetekst" runat="server" Text="Tittel:"></asp:Label>
    <asp:TextBox ID="Tittelfelt" runat="server" Width="519px"></asp:TextBox>&nbsp;
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Tittelfelt"
        ErrorMessage="Tittel må fylles ut"></asp:RequiredFieldValidator><br />
    <asp:Label ID="Datoledetekst" runat="server" Text="Tidspunkt:"></asp:Label>
    <asp:Label ID="Datofelt" runat="server"></asp:Label><br />
    <asp:TextBox ID="Innleggstekst" runat="server" Height="185px" TextMode="MultiLine" Width="737px"></asp:TextBox>
    
    <table id="Table1" runat="server" class="x-innleggstabell" >
        <tbody>
        </tbody>
    </table>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Send endringer" />

</asp:Content>

