<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="adminMain.aspx.cs" Inherits="adminMain" Title="Administratorside" %>

<%@ Register Src="kategori.ascx" TagName="kat" TagPrefix="uc1" %>
<%@ Register Src="~/produkt.ascx" TagName="pro" TagPrefix="uc2" %>
<%@ Register Src="kategoriadmin.ascx" TagName="katadm" TagPrefix="uc3" %>
<%@ Reference Control="produkt.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <uc1:kat ID="kategori" runat="server" />

    <div class="adminmeny">
        &nbsp;&nbsp;&nbsp;Velg hva du vil&nbsp; administrere:
        <asp:DropDownList ID="Oppgavevelger" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Oppgavevelger_SelectedIndexChanged" Width="214px">
            <asp:ListItem Value="-1" Text=""></asp:ListItem>
        </asp:DropDownList>
    </div>
    <div class="Oppgavediv">
        <asp:MultiView ID="Oppgaveview" runat="server">
            <asp:View ID="Kategorier" runat="server">
                <uc3:katadm ID="kategoriadm" runat="server" Visible="true" />
            </asp:View>
            <asp:View ID="Nyheter" runat="server">
                <asp:Label ID="OverskriftLabel" runat="server">Overskrift</asp:Label>
                <br />
                <asp:TextBox ID="Overskrift" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="TekstLabel" runat="server">Tekst</asp:Label>
                <br />
                <asp:TextBox ID="Tekst" runat="server" TextMode="MultiLine"></asp:TextBox>
                <br />
                <asp:Button ID="Send" runat="server" Text="Send" />
            </asp:View>
            <asp:View ID="Varer" runat="server">
                Her skal det snart blir mulighet for å redigere varer.<asp:FormView ID="FormView1"
                    runat="server">
                    <ItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                    </ItemTemplate>
                </asp:FormView>
            </asp:View>
        </asp:MultiView>
    </div>
</asp:Content>
