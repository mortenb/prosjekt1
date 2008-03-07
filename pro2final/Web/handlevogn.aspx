<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="handlevogn.aspx.cs" Inherits="handlevogn" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    Her kan du se innholdet i handlevognen din:<br />
    &nbsp;&nbsp;
    <br />
    <asp:GridView ID="GridView1" runat="server" DataSourceID="Varer" AutoGenerateColumns="False" >
        <Columns>
            <asp:BoundField DataField="ProduktID" HeaderText="ProduktID" SortExpression="ProduktID" />
            <asp:BoundField DataField="Varenavn" HeaderText="Varenavn" SortExpression="Varenavn" />
            <asp:BoundField DataField="Antall" HeaderText="Antall" SortExpression="Antall" />
            <asp:BoundField DataField="Pris" HeaderText="Pris" SortExpression="Pris" />
            <asp:BoundField DataField="Sum" HeaderText="Sum" SortExpression="Sum" />
            <asp:ButtonField CommandName="Delete" HeaderText="Slett" ShowHeader="True" Text="Fjern linje" />
        </Columns>
        <EmptyDataTemplate>
            Du har ingen varer i handlevognen!
        </EmptyDataTemplate>
    </asp:GridView>
    <br />
    <asp:Label ID="Label1" runat="server"></asp:Label><br />
    <asp:ObjectDataSource ID="Varer" runat="server" SelectMethod="lagOrdreliste" TypeName="Handlevogn">
    </asp:ObjectDataSource>
    <br />
    &nbsp;&nbsp;<br />
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="Varer">
        <Columns>
            <asp:BoundField DataField="Varenavn" HeaderText="Varenavn" SortExpression="Varenavn" />
            <asp:BoundField DataField="Antall" HeaderText="Antall" SortExpression="Antall" />
            <asp:BoundField DataField="ProduktID" HeaderText="ProduktID" SortExpression="ProduktID" />
            <asp:BoundField DataField="Sum" HeaderText="Sum" SortExpression="Sum" />
            <asp:BoundField DataField="Pris" HeaderText="Pris" SortExpression="Pris" />
        </Columns>
    </asp:GridView>
    <br />
    &nbsp;<asp:Button ID="Button1" runat="server" Text="Slett Handlevogn" OnClick="Button1_Click" />
    <asp:Button ID="Button2" runat="server" Text="Gå til kassen" OnClick="Button2_Click" /><br />
    &nbsp;<br />
    &nbsp;
</asp:Content>

