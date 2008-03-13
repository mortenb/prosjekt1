<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login"
    Title="Innlogging" MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Login ID="Login1" DestinationPageUrl="~/Default.aspx" runat="server" FailureText="Innloggingen feilet. Vennligst pr�v igjen."
            LoginButtonText="Logg inn" PasswordLabelText="Passord:" RememberMeText="Husk meg neste gang."
            TitleText="Innlogging" UserNameLabelText="Brukernavn:">
        </asp:Login>
        <asp:HyperLink ID="Registrer" runat="server" NavigateUrl="~/NyKunde.aspx">Ny kunde</asp:HyperLink>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Glemt passordet?</asp:LinkButton><br />
        <asp:PasswordRecovery ID="PasswordRecovery1" runat="server" AnswerLabelText="Svar:"
            AnswerRequiredErrorMessage="Svar m� oppgis" GeneralFailureText="Noe gikk galt under fors�ket p� � hente passordet."
            QuestionFailureText="Svaret kunne ikke verifiseres. Vennligst pr�v igjen" QuestionInstructionText="Svar p� f�lgende sp�rsm�l for � f� tilgang til pasordet ditt "
            QuestionLabelText="Sp�rsm�l:" QuestionTitleText="Identitetsbekreftelse" SubmitButtonText="Send"
            SuccessText="Passordet har blitt sendt til deg" UserNameFailureText="Vi kunne ikkke finne informasjon om din bruker. Vennligst pr�v igjen"
            UserNameInstructionText="Oppgi ditt brukernavn" UserNameLabelText="Brukernavn:"
            UserNameRequiredErrorMessage="Brukernavn m� oppgis" UserNameTitleText="Har du glemt passordet?"
            OnSendingMail="PasswordRecovery1_SendingMail"
            Visible="False" MailDefinition-Subject="Ditt Passord til webshoppen">
            <QuestionTemplate>
                <table border="0" cellpadding="1" cellspacing="0" style="border-collapse: collapse">
                    <tr>
                        <td>
                            <table border="0" cellpadding="0">
                                <tr>
                                    <td align="center" colspan="2">
                                        Identitetsbekreftelse</td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        Svar p� f�lgende sp�rsm�l for � f� tilgang til pasordet ditt
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        Brukernavn:</td>
                                    <td>
                                        <asp:Literal ID="UserName" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        Sp�rsm�l:</td>
                                    <td>
                                        <asp:Literal ID="Question" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="AnswerLabel" runat="server" AssociatedControlID="Answer">Svar:</asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="Answer" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="AnswerRequired" runat="server" ControlToValidate="Answer"
                                            ErrorMessage="Svar m� oppgis" ToolTip="Svar m� oppgis" ValidationGroup="PasswordRecovery1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2" style="color: red">
                                        <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2">
                                        <asp:Button ID="SubmitButton" runat="server" CommandName="Submit" Text="Send" ValidationGroup="PasswordRecovery1" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </QuestionTemplate>
        </asp:PasswordRecovery>
    </div>
</asp:Content>
