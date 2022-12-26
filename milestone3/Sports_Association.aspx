<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sports_Association.aspx.cs" Inherits="milestone3.Sports_Association" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Sports association manager"></asp:Label>
        </div>
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            <asp:ListItem>Select an action</asp:ListItem>
            <asp:ListItem>Add a match</asp:ListItem>
            <asp:ListItem>delete a match</asp:ListItem>
            <asp:ListItem>view all upcoming matches</asp:ListItem>
            <asp:ListItem>view already played matches</asp:ListItem>
            <asp:ListItem>View pair of club names who never scheduled to play with each other</asp:ListItem>
        </asp:DropDownList>
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
                <br />
                <br />
                <asp:Label ID="Label2" runat="server" Text="Host club"></asp:Label>
                <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource1" DataTextField="name" DataValueField="name">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Milestone2#1ConnectionString %>" SelectCommand="SELECT DISTINCT [name] FROM [Club]"></asp:SqlDataSource>
                <asp:Label ID="Label3" runat="server" Text="Guest club"></asp:Label>
                <asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="SqlDataSource1" DataTextField="name" DataValueField="name">
                </asp:DropDownList>
                <br />
                <asp:Label ID="Label4" runat="server" Text="Start time"></asp:Label>
                <asp:TextBox ID="start_time" runat="server" type="datetime-local" ></asp:TextBox>
                <br />
                <asp:Label ID="Label5" runat="server" Text="End time"></asp:Label>
                <asp:TextBox ID="end_time" runat="server" type="datetime-local"></asp:TextBox>
                <br />
                <asp:Button ID="Button1" runat="server" Text="add match" OnClick="addMatch"  />
            </asp:View>
            <asp:View ID="View2" runat="server">
            </asp:View>
            <asp:View ID="View3" runat="server">
            </asp:View>
            <asp:View ID="View4" runat="server">
            </asp:View>
            <asp:View ID="View5" runat="server">
            </asp:View>
        </asp:MultiView>
    </form>
</body>
</html>
