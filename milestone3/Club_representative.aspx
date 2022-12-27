<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Club_representative.aspx.cs" Inherits="milestone3.Club_representative" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Club Representative<br />
            <br />
            Club ID:
            <asp:Label ID="clubID" runat="server" Text=""></asp:Label>
            <br />
            <br />
            Club Name:
            <asp:Label ID="clubName" runat="server" Text=""></asp:Label>
            <br />
            <br />
            Club Location:
            <asp:Label ID="clubLocation" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:GridView ID="upcomingMatchesTable" runat="server" AutoGenerateColumns="false">
                 <Columns>
        <asp:BoundField DataField="FirstClub" HeaderText="First Club" />
        <asp:BoundField DataField="SecondClub" HeaderText="Second Club" />
        <asp:BoundField DataField="start_time" HeaderText="Start Time" />
        <asp:BoundField DataField="end_time" HeaderText="End Time" />
        <asp:BoundField DataField="name" HeaderText="Stadium Name" />
                 </Columns>
            </asp:GridView>

            <br />
            Available Stadiums Starting :
            <asp:TextBox ID="dateInput" runat="server" type="date"></asp:TextBox>

            <asp:Button ID="Button1" runat="server" Text="View" OnClick="viewStadiums" style="width: 42px" />

            <br />
            <asp:GridView ID="stadiumsTable" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="name" HeaderText="Stadium Name" />
                    <asp:BoundField DataField="location" HeaderText="Stadium Location" />
                    <asp:BoundField DataField="capactiy" HeaderText="Stadium Capacity" />
                </Columns>
            </asp:GridView>
            <br />
            Send Host Request:<br />
            <br />
            Request at Stadium :&nbsp;
            <asp:DropDownList ID="stadiumDropDown" runat="server" DataSourceID="SqlDataSource1" DataTextField="name" DataValueField="name">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Milestone2#1ConnectionString %>" SelectCommand="SELECT [name] FROM [allStadiums]"></asp:SqlDataSource>
&nbsp;For Match starting At:&nbsp;&nbsp;
            <asp:DropDownList ID="upcomingMatchesDropDown" runat="server">
            </asp:DropDownList>
            <asp:Button ID="Button2" runat="server" Text="Send Request" OnClick="sendRequest" />
            <asp:Label ID="requestSentNotification" runat="server" Text=""></asp:Label>
            <br />
            <br />

        </div>
    </form>
</body>
</html>
