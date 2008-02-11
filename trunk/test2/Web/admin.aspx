<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin.aspx.cs" Inherits="test" MasterPageFile="~/master.master"%>
<%@ MasterType TypeName="master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"  >
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/editRoles.aspx">Rediger roller</asp:HyperLink>
         <asp:Panel ID="Panel1" runat="server" Height="500px" Width="400px">
        <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" LoginCreatedUser="False" RequireEmail="False" OnCreatedUser="CreateUserWizard1_CreatedUser1" CreateUserButtonText="Lag ny bruker" FinishCompleteButtonText="Fullfør" FinishPreviousButtonText="Forrige" InvalidPasswordErrorMessage="Passordet må minst være på {0} tegn, og må inneholde minst {1}. ikke-alfanummerisk tegn." UnknownErrorMessage=" Kontoen ble ikke opprettet, vennligst prøv igjen.">
            <WizardSteps>
                <asp:CreateUserWizardStep runat="server">
                    <ContentTemplate>
                        <table border="0">
                            <tr>
                                <td align="center" colspan="2">
                                    Opprett en ny bruker</td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Brukernavn:</asp:Label></td>
                                <td>
                                    <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                        ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Passord:</asp:Label></td>
                                <td>
                                    <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                        ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword">Bekreft passord:</asp:Label></td>
                                <td>
                                    <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" ControlToValidate="ConfirmPassword"
                                        ErrorMessage="Confirm Password is required." ToolTip="Confirm Password is required."
                                        ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="QuestionLabel" runat="server" AssociatedControlID="Question">Sikkerhetsspørsmål:</asp:Label></td>
                                <td>
                                    <asp:TextBox ID="Question" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="QuestionRequired" runat="server" ControlToValidate="Question"
                                        ErrorMessage="Security question is required." ToolTip="Security question is required."
                                        ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="AnswerLabel" runat="server" AssociatedControlID="Answer">Svar på spørsmål::</asp:Label></td>
                                <td>
                                    <asp:TextBox ID="Answer" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="AnswerRequired" runat="server" ControlToValidate="Answer"
                                        ErrorMessage="Security answer is required." ToolTip="Security answer is required."
                                        ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password"
                                        ControlToValidate="ConfirmPassword" Display="Dynamic" ErrorMessage='Verdien i feltet "Bekreft passord" er ikke lik verdien i "Passord"'
                                        ValidationGroup="CreateUserWizard1"></asp:CompareValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2" style="color: red">
                                    <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:CreateUserWizardStep>
                <asp:WizardStep runat="server" Title="Lag blogg">
                    Forsøker å lage blogg</asp:WizardStep>
                <asp:CompleteWizardStep runat="server">
                    <ContentTemplate>
                        <table border="0">
                            <tr>
                                <td align="center" colspan="2">
                                    Fullført</td>
                            </tr>
                            <tr>
                                <td style="width: 269px">
                                    Kontoen har blitt opprettet</td>
                            </tr>
                            <tr>
                                <td align="right" colspan="2">
                                    <asp:Button ID="ContinueButton" runat="server" CausesValidation="False" CommandName="Continue"
                                        OnClick="ContinueButton_Click" Text="Fortsett" ValidationGroup="CreateUserWizard1" />
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:CompleteWizardStep>
            </WizardSteps>
        </asp:CreateUserWizard>
       
        </asp:Panel>
        <br />
        
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            SelectCommand="SELECT * FROM [blogg]" DeleteCommand="DELETE FROM [blogg] WHERE [id] = @id" InsertCommand="INSERT INTO [blogg] ([eier], [tittel]) VALUES (@eier, @tittel)" UpdateCommand="UPDATE [blogg] SET [eier] = @eier, [tittel] = @tittel WHERE [id] = @id">
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="eier" Type="String" />
                <asp:Parameter Name="tittel" Type="String" />
                <asp:Parameter Name="id" Type="Int32" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="eier" Type="String" />
                <asp:Parameter Name="tittel" Type="String" />
            </InsertParameters>
        </asp:SqlDataSource>
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="eier" HeaderText="eier" SortExpression="eier" />
                <asp:BoundField DataField="tittel" HeaderText="tittel" SortExpression="tittel" />
                <asp:CheckBoxField HeaderText="Admin"  />
                <asp:ButtonField Text="Slett" />
            </Columns>
        </asp:GridView>
</asp:Content>