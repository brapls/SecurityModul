<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="calendarM133.Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-6">
            <h1>Registration</h1>
            <asp:Label Text="" CssClass="redText" runat="server" ID="lblErrors"/>
            <div id="Login">
                <table>
                    <tr>
                        <td>
                            <asp:label runat="server">Username</asp:label>
                        </td>
                        <td>
                            <asp:Textbox runat="server" placeholder="Bitte geben Sie Ihren Username ein" id="tbUsername" required="true"></asp:Textbox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:label runat="server">Passwort</asp:label>
                        </td>
                        <td>
                            <asp:textbox runat="server" type="password" placeholder="Bitte geben Sie Ihr Passwort ein" id="tbPassword" required="true"></asp:textbox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:label runat="server">Passwort wiederholung</asp:label>
                        </td>
                        <td>
                            <asp:textbox runat="server" type="password" placeholder="Bitte geben Sie Ihr Passwort ein" id="tbPassword2" required="true"></asp:textbox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button runat="server" ID="butRegistration" onclick="butRegistration_Click" OnClientClick="validate()" Text="Registrieren"/>
                        </td>
                        <td>
                            <asp:Button runat="server" ID="butLogin" onclick="butLogin_Click" CausesValidation="false" Text="Zum Login"  />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
