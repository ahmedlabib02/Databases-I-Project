<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="System_admin.aspx.cs" Inherits="milestone3.System_admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
</body>
</html>
    <p>
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            <asp:ListItem>-------</asp:ListItem>
            <asp:ListItem>Add club</asp:ListItem>
            <asp:ListItem>Delete club</asp:ListItem>
            <asp:ListItem>Add stadium</asp:ListItem>
            <asp:ListItem>delete stadium</asp:ListItem>
            <asp:ListItem>Block fan</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
                <asp:Label ID="Label1" runat="server" Text="club name"></asp:Label>
                <asp:TextBox ID="club_name" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="Label2" runat="server" Text="club location"></asp:Label>
                <asp:TextBox ID="club_location" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="Button1" runat="server" Text="add club" OnClick="addClub" />
                <br />
            </asp:View>
            <asp:View ID="View2" runat="server">
                &nbsp;club name<asp:TextBox ID="club_name2" runat="server"></asp:TextBox>
                <br />
                <asp:Button ID="Button2" runat="server" Text="delete " OnClick="deleteClub" />
            </asp:View>
            <asp:View ID="View3" runat="server">
                stadium name<asp:TextBox ID="stadium_name" runat="server"></asp:TextBox>
                <br />
                stadium location<asp:TextBox ID="stadium_loc" runat="server"></asp:TextBox>
                <br />
                stadium capactiy<asp:TextBox ID="stadium_cap" runat="server"></asp:TextBox>
                <br />
                <asp:Button ID="Button3" runat="server" Text="add stadium" OnClick="addStadium" />
            </asp:View>
            <asp:View ID="View4" runat="server">
                <asp:Label ID="Label3" runat="server" Text="stadium name"></asp:Label>
                <asp:TextBox ID="stadium_name2" runat="server"></asp:TextBox>
                <br />
                <asp:Button ID="Button4" runat="server" Text="delete stadium" OnClick="deleteStadium"  />
            </asp:View>
            <asp:View ID="View5" runat="server">
                <asp:Label ID="Label4" runat="server" Text="Fan national id"></asp:Label>
                <asp:TextBox ID="national_id" runat="server"></asp:TextBox>
                <br />
                <asp:Button ID="Button5" runat="server" Text="Block" OnClick="blockFan" />
                <br />
            </asp:View>
        </asp:MultiView>
    </p>
    </form>

