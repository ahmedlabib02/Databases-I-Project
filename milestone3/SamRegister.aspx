<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SamRegister.aspx.cs" Inherits="milestone3.SamRegister" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Register as Sports Association Manager<br />
            <br />
            Name:&nbsp;&nbsp;
            <asp:TextBox ID="samNameTxt" runat="server" Width="180px"></asp:TextBox>
            <br />
            <br />
            Username:&nbsp;&nbsp; <asp:TextBox ID="samUsernameTxt" runat="server" Width="159px"></asp:TextBox>
            <br />
            <br />
            Password:&nbsp;&nbsp;
            <asp:TextBox ID="samPasswordTxt" runat="server" Width="158px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Register" OnClick="samReg" />
        </div>
    </form>
</body>
</html>
