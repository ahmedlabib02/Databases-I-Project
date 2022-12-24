<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClubRepRegister.aspx.cs" Inherits="milestone3.ClubRepRegister" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Register as Club Representative<br />
            <br />
            Name:&nbsp;&nbsp;
            <asp:TextBox ID="repNameTxt" runat="server" Width="167px"></asp:TextBox>
            <br />
            <br />
            Club Name:&nbsp;&nbsp;
            <asp:TextBox ID="clubNameTxt" runat="server" Width="132px"></asp:TextBox>
            <br />
            <br />
            Username:&nbsp;&nbsp;
            <asp:TextBox ID="repUsernameTxt" runat="server" Width="140px"></asp:TextBox>
            <br />
            <br />
            Password:&nbsp;&nbsp;
            <asp:TextBox ID="repPasswordTxt" runat="server" Width="139px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Register" OnClick="repReg" />
        </div>
    </form>
</body>
</html>
