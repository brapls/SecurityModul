<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateTermin.aspx.cs" Inherits="calendarM133.CreateTermin" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-6">
            <h2>Termin erstellen</h2>
            <div>
                <asp:Label runat="server" ID="lblTerminCreateError" Text="" CssClass="redText"/><br />
                Betreff:<br /> 
                <asp:TextBox ID="tbSubject" runat="server"/><br />
                Anfangsdatum: <br />
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <asp:Calendar ID="calStartDate" runat="server"/><br />
                        Enddatum: <br />
                        <asp:Calendar ID="calEndDate" runat="server"/><br />
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:Button ID="btnCreateTermin" runat="server" Text="Termin erstellen" OnClick="btnCreateTermin_Click" />
            </div>
        </div>
    </div>
</asp:Content>
