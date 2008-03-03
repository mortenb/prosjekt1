<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NyKunde.aspx.cs" Inherits="NyKunde" MasterPageFile="~/MasterPage.master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"  >

    <div>
        &nbsp;<asp:CreateUserWizard ID="CreateUserWizard1" runat="server" AnswerRequiredErrorMessage="Sikkerhetssvar er påkrevd" CancelButtonText="Avbryt" CompleteSuccessText="Kontoen din har blitt opprettet." ConfirmPasswordCompareErrorMessage="Passordene du har oppgitt er ikke like." ConfirmPasswordRequiredErrorMessage="Du må gjenta passordet" ContinueButtonText="Fortsett" CreateUserButtonText="Neste" EmailRegularExpressionErrorMessage="Vennligst oppgi en annen e-postadresse." EmailRequiredErrorMessage="E-postadresse må oppgis" FinishCompleteButtonText="Fullfør" PasswordLabelText="Passord:" PasswordRegularExpressionErrorMessage="Vennligst oppgi et annet passord" PasswordRequiredErrorMessage="Passord må oppgis" QuestionLabelText="Sikkerhetsspørsmål" QuestionRequiredErrorMessage="Sekkerhetsspørsmål må oppgis" StartNextButtonText="Neste" StepNextButtonText="Neste" StepPreviousButtonText="Forrige" UnknownErrorMessage="Kontoen ble ikke opprettet, vennligst prøv igjen" UserNameRequiredErrorMessage="Du må oppgi et brukernavn." OnCreatedUser="CreateUserWizard1_CreatedUser" DuplicateEmailErrorMessage="E-postadressen er eallerede i bruk. Vennligst velg en annen e-postadresse." DuplicateUserNameErrorMessage="Vennligst velg et annet brukernavn" FinishPreviousButtonText="Forrige" InvalidAnswerErrorMessage="Vennligst oppgi et annet svar på sikkerhetsspørsmålet" InvalidEmailErrorMessage="Vennligst oppgi en gyldig e-postadresse" InvalidPasswordErrorMessage="Minimum passordlnegde er  {0} tegn. Minst {1} tegn må være ikke-alfanummerisk." InvalidQuestionErrorMessage="Vennligst velg et annet sikkerhetsspørsmål" >
            <WizardSteps>
                <asp:CreateUserWizardStep runat="server">
                    <ContentTemplate>
                        <table border="0">
                            <tr>
                                <td align="center" colspan="2">
                                    Registrer deg som kunde</td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Brukernavn:</asp:Label></td>
                                <td>
                                    <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                        ErrorMessage="Du må oppgi et brukernavn" ToolTip="Du må velge et brukernavn (påkrevd)"
                                        ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Passord:</asp:Label></td>
                                <td>
                                    <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                        ErrorMessage="Du må oppgi et passord." ToolTip="Velg et passord." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword">Bekreft passord:</asp:Label></td>
                                <td>
                                    <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" ControlToValidate="ConfirmPassword"
                                        ErrorMessage="Du må gjenta passordet." ToolTip="Gjenta passordet" ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">E-postadresse:</asp:Label></td>
                                <td>
                                    <asp:TextBox ID="Email" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email"
                                        ErrorMessage="Du må oppgi en e-postadresse" ToolTip="Skriv inn e-postadressen din."
                                        ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="QuestionLabel" runat="server" AssociatedControlID="Question">Sikkerhetsspørsmål:</asp:Label></td>
                                <td>
                                    <asp:TextBox ID="Question" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="QuestionRequired" runat="server" ControlToValidate="Question"
                                        ErrorMessage="Du må oppgi et sikkerhetsspørsmål" ToolTip="Oppgi et sikkerhetsspørsmål som kan brukes for å få tilsendt passordet."
                                        ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="AnswerLabel" runat="server" AssociatedControlID="Answer">Sikkerhetssvar</asp:Label></td>
                                <td>
                                    <asp:TextBox ID="Answer" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="AnswerRequired" runat="server" ControlToValidate="Answer"
                                        ErrorMessage="Svar på sikkerhetsspørsmålet kreves" ToolTip="Skriv svaret på sikkerhetsspørsmålet."
                                        ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password"
                                        ControlToValidate="ConfirmPassword" Display="Dynamic" ErrorMessage="Passordene du har skrevet er ikke like"
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
                <asp:CompleteWizardStep runat="server">
                    <ContentTemplate>
                        <table border="0">
                            <tr>
                                <td align="center" colspan="2">
                                    Fullført</td>
                            </tr>
                            <tr>
                                <td style="height: 21px">
                                    Kontoen din har blitt opprettet.</td>
                            </tr>
                            <tr>
                                <td align="right" colspan="2">
                                    <asp:Button ID="ContinueButton" runat="server" CausesValidation="False" CommandName="Continue"
                                        Text="Fortsett" ValidationGroup="CreateUserWizard1" PostBackUrl="~/Default.aspx" />
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:CompleteWizardStep>
            </WizardSteps>
        </asp:CreateUserWizard>
        &nbsp;</div>
</asp:Content>
