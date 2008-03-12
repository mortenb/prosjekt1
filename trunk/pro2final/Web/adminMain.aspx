<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="adminMain.aspx.cs" Inherits="adminMain" Title="Administratorside" %>

<%@ Register Src="kategori.ascx" TagName="kat" TagPrefix="uc1" %>
<%@ Register Src="~/produkt.ascx" TagName="pro" TagPrefix="uc2" %>
<%@ Register Src="kategoriadmin.ascx" TagName="katadm" TagPrefix="uc3" %>
<%@ Register Src="produktadmin.ascx" TagName="proadm" TagPrefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <uc1:kat ID="kategori" runat="server" />
    <div class="hovedinnhold">
        <div class="x-admindiv">
            Velg hva du vil administrere:<br/>
            <asp:DropDownList ID="Oppgavevelger" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Oppgavevelger_SelectedIndexChanged"
                Width="250px">
                <asp:ListItem Value="-1" Text=""></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="x-admindiv">
            <asp:MultiView ID="Oppgaveview" runat="server">
                <asp:View ID="Kategorier" runat="server">
                    <uc3:katadm ID="kategoriadm" runat="server" Visible="true" />
                </asp:View>
                <asp:View ID="Nyheter" runat="server">
                    <asp:Label ID="OverskriftLabel" runat="server">Overskrift</asp:Label>
                    <br />
                    <asp:TextBox ID="Overskrift" runat="server" CausesValidation="True"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Overskrift"
                        ErrorMessage="Feltet kan ikke være tomt!" ValidationGroup="NyhetVal"></asp:RequiredFieldValidator><br />
                    <asp:Label ID="TekstLabel" runat="server">Tekst</asp:Label>
                    <br />
                    <asp:TextBox ID="Tekst" runat="server" TextMode="MultiLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="NyhetTekstVal" runat="server" ControlToValidate="Tekst"
                        ErrorMessage="Feltet kan ikke være tomt!" ValidationGroup="NyhetVal"></asp:RequiredFieldValidator><br />
                    <asp:Button ID="Send" runat="server" Text="Send" OnClick="Send_Click" ValidationGroup="NyhetVal" />
                </asp:View>
                <asp:View ID="Varer" runat="server">
                    <uc4:proadm ID="produktadm" runat="server" Visible="true" />
                </asp:View>
            </asp:MultiView>
        </div>
    </div>
</asp:Content>
