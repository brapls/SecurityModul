<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="calendarM133._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-6">
            <h2>Eingeladene Termine</h2>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <asp:GridView runat="server" ID="gvInvited">
                        <EmptyDataTemplate>
                            Sie haben keine offenen Einladungen.
                        </EmptyDataTemplate>
                    </asp:GridView>
                    <div id="invitedToSection" runat="server">
                        Termin Auswählen:<br />
                        <asp:DropDownList ID="ddlInvitedTermin" runat="server"/><br />
                        <asp:Button ID="btnAccept" Text="Accept" runat="server" OnClick="btnAccept_Click"/><asp:Button ID="btnReject" Text="Reject" runat="server" OnClick="btnReject_Click"/>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <h2>Kommende Termine</h2>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <asp:GridView runat="server" ID="gvCalendar">
                        <EmptyDataTemplate>
                            Sie haben keine zukünftigen Termine mehr.
                        </EmptyDataTemplate>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
            <h2>Termine nach Tag suchen</h2>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <asp:Calendar runat="server" ID="calDayChoice" OnSelectionChanged="calDayChoice_SelectionChanged"></asp:Calendar>
                </ContentTemplate>
            </asp:UpdatePanel>
            <h2>Termine an dem Ausgewählem Tag:</h2>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <asp:GridView runat="server" ID="gvDailyCalendar">
                        <EmptyDataTemplate>
                            An diesem Tag haben Sie keine Termine.
                        </EmptyDataTemplate>    
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
