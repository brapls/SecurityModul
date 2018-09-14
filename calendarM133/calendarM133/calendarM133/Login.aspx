<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="calendarM133.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="row">
        <div class="col-md-6">
            <h1>Calendar</h1>
            <asp:Label Text="Der Username oder das Passwort ist falsch." CssClass="invalidLable redText" visible="false" runat="server" ID="lblInvalidPassword"/>
            <div id="Login">
                <table>
                    <tr>
                        <td>
                            <asp:label runat="server">Username</asp:label>
                        </td>
                        <td>
                            <asp:Textbox runat="server" placeholder="Bitte geben Sie Ihren Username ein" id="tbUsername" ></asp:Textbox>
                            <asp:RequiredFieldValidator ControlToValidate="tbUsername" ValidationGroup="valLogin" runat="server"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:label runat="server">Passwort</asp:label>
                        </td>
                        <td>
                            <asp:textbox runat="server" type="password" placeholder="Bitte geben Sie Ihr Passwort ein"  id="tbPassword"></asp:textbox>
                            <asp:RequiredFieldValidator ControlToValidate="tbPassword" ValidationGroup="valLogin" runat="server"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button runat="server" ID="butLogin" OnClientClick="validate" onclick="butLogin_Click" Text="Login"  ValidationGroup="valLogin"/>
                        </td>
                        <td>
                            <asp:Button runat="server" ID="butRegistration"  onclick="butRegistration_Click" CausesValidation="false" Text="Registration" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
