<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Fans.aspx.cs" Inherits="milestone3.Fans" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <br />
        <br />
        Select a date for the matches
        <asp:TextBox ID="start_time" runat="server" type="datetime-local"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="search" OnClick="Button1_Click" />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand">
            <Columns>
                <asp:BoundField DataField="hostclub" HeaderText="Host club" />
                <asp:BoundField DataField="Competingclub" HeaderText="Guest club" />
                <asp:BoundField DataField="name" HeaderText="Stadium name" />
                <asp:BoundField DataField="location" HeaderText="location" />
                <asp:ButtonField CommandName="Purchase" Text="Purchase ticket" />
            </Columns>
        </asp:GridView>
        <br />
    </form>
</body>
</html>
