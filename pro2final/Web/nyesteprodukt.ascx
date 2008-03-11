<%@ Control Language="C#" AutoEventWireup="true" CodeFile="nyesteprodukt.ascx.cs" Inherits="nyesteprodukt" %>
<asp:FormView ID="FormView1" runat="server" DataSourceID="ObjectDataSource1">
    <EditItemTemplate>
        AntallPaaLager:
        <asp:TextBox ID="AntallPaaLagerTextBox" runat="server" Text='<%# Bind("AntallPaaLager") %>'>
        </asp:TextBox><br />
        ProduktkategoriID:
        <asp:TextBox ID="ProduktkategoriIDTextBox" runat="server" Text='<%# Bind("ProduktkategoriID") %>'>
        </asp:TextBox><br />
        Tittel:
        <asp:TextBox ID="TittelTextBox" runat="server" Text='<%# Bind("Tittel") %>'>
        </asp:TextBox><br />
        Beskrivelse:
        <asp:TextBox ID="BeskrivelseTextBox" runat="server" Text='<%# Bind("Beskrivelse") %>'>
        </asp:TextBox><br />
        ProduktID:
        <asp:TextBox ID="ProduktIDTextBox" runat="server" Text='<%# Bind("ProduktID") %>'>
        </asp:TextBox><br />
        Pris:
        <asp:TextBox ID="PrisTextBox" runat="server" Text='<%# Bind("Pris") %>'>
        </asp:TextBox><br />
        BildeURL:
        <asp:TextBox ID="BildeURLTextBox" runat="server" Text='<%# Bind("BildeURL") %>'>
        </asp:TextBox><br />
        <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
            Text="Update">
        </asp:LinkButton>
        <asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
            Text="Cancel">
        </asp:LinkButton>
    </EditItemTemplate>
    <InsertItemTemplate>
        AntallPaaLager:
        <asp:TextBox ID="AntallPaaLagerTextBox" runat="server" Text='<%# Bind("AntallPaaLager") %>'>
        </asp:TextBox><br />
        ProduktkategoriID:
        <asp:TextBox ID="ProduktkategoriIDTextBox" runat="server" Text='<%# Bind("ProduktkategoriID") %>'>
        </asp:TextBox><br />
        Tittel:
        <asp:TextBox ID="TittelTextBox" runat="server" Text='<%# Bind("Tittel") %>'>
        </asp:TextBox><br />
        Beskrivelse:
        <asp:TextBox ID="BeskrivelseTextBox" runat="server" Text='<%# Bind("Beskrivelse") %>'>
        </asp:TextBox><br />
        ProduktID:
        <asp:TextBox ID="ProduktIDTextBox" runat="server" Text='<%# Bind("ProduktID") %>'>
        </asp:TextBox><br />
        Pris:
        <asp:TextBox ID="PrisTextBox" runat="server" Text='<%# Bind("Pris") %>'>
        </asp:TextBox><br />
        BildeURL:
        <asp:TextBox ID="BildeURLTextBox" runat="server" Text='<%# Bind("BildeURL") %>'>
        </asp:TextBox><br />
        <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
            Text="Insert">
        </asp:LinkButton>
        <asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
            Text="Cancel">
        </asp:LinkButton>
    </InsertItemTemplate>
    <ItemTemplate>
        AntallPaaLager:
        <asp:Label ID="AntallPaaLagerLabel" runat="server" Text='<%# Bind("AntallPaaLager") %>'>
        </asp:Label><br />
        ProduktkategoriID:
        <asp:Label ID="ProduktkategoriIDLabel" runat="server" Text='<%# Bind("ProduktkategoriID") %>'>
        </asp:Label><br />
        Tittel:
        <asp:Label ID="TittelLabel" runat="server" Text='<%# Bind("Tittel") %>'></asp:Label><br />
        Beskrivelse:
        <asp:Label ID="BeskrivelseLabel" runat="server" Text='<%# Bind("Beskrivelse") %>'>
        </asp:Label><br />
        ProduktID:
        <asp:Label ID="ProduktIDLabel" runat="server" Text='<%# Bind("ProduktID") %>'></asp:Label><br />
        Pris:
        <asp:Label ID="PrisLabel" runat="server" Text='<%# Bind("Pris") %>'></asp:Label><br />
        BildeURL:
        <asp:Label ID="BildeURLLabel" runat="server" Text='<%# Bind("BildeURL") %>'></asp:Label><br />
    </ItemTemplate>
</asp:FormView>
<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="getNyesteProduktFraPK"
    TypeName="myApp.BLL.ProduktBLL">
    <SelectParameters>
        <asp:ProfileParameter Name="brukernavn" PropertyName="UserName" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
