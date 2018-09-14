<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddPersonToTermin.aspx.cs" Inherits="calendarM133.AddPersonToTermin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-md-6">
        <h2>Person zu Termin einladen</h2>
        <div>
            <asp:Label ID="lblError" CssClass="redText" runat="server"></asp:Label>
            <table>
                <tr>
                    <td>Einladung zu Termin:</td><td><asp:DropDownList ID="ddlTerminSelection" runat="server"/></td>
                </tr>
                <tr>
                    <td>Für Person:</td><td><asp:DropDownList ID="ddlPerson" runat="server"/></td>
                </tr>
            </table>
            <asp:Button ID="btnTermin" runat="server" Text="Person einladen" OnClick="btnTermin_Click" />
        </div>
    </div>
</asp:Content>
