<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="index.aspx.cs" Inherits="_Default" Trace="true"  MasterPageFile="~/master.master" Title="Hovedside" %>

<%@ MasterType TypeName="master" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
    <div>
        <br />
    Hvilken blogg vil du inn på?&nbsp;
    <asp:GridView ID="GridView_blogger" runat="server" AutoGenerateColumns="false">
        <Columns>
                <asp:HyperLinkField DataTextField="tittel" DataNavigateUrlFields="eier" DataNavigateUrlFormatString="~/blogg.aspx?blog={0}" />
            </Columns>
    </asp:GridView>
        &nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Text="En enkelt blogg"></asp:Label>
        <asp:GridView ID="GridView_blogg" AutoGenerateColumns="false" runat="server">
        <Columns>
            <asp:BoundField DataField="tittel" SortExpression="true" HeaderText="Bloggen" />
        </Columns>
        </asp:GridView>
        
    </div>
    </asp:Content>
