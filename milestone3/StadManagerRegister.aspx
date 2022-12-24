<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StadManagerRegister.aspx.cs" Inherits="milestone3.StadManagerRegister" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Register as Stadium Manager<br />
            <br />
            Name:&nbsp;&nbsp;
            <asp:TextBox ID="smNameTxt" runat="server" Width="179px"></asp:TextBox>
            <br />
            <br />
            Stadium Name:&nbsp;&nbsp;
            <asp:TextBox ID="stadiumNameTxt" runat="server" Width="124px"></asp:TextBox>
            <br />
            <br />
            Username:&nbsp;&nbsp;
            <asp:TextBox ID="smUsernameTxt" runat="server" Width="151px"></asp:TextBox>
            <br />
            <br />
            Password:&nbsp;&nbsp;
            <asp:TextBox ID="smPasswordTxt" runat="server" Width="149px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Register" OnClick="StadManagerReg" />
        </div>
    </form>
</body>
</html>
