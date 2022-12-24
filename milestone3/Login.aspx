<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="milestone3.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        Please log in here<p>
            Username</p>
        <p>
            <asp:TextBox ID="t1" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
        </p>
        <p>
            Password</p>
        <p>
            <asp:TextBox ID="t2" runat="server"></asp:TextBox>
        </p>
        <asp:Button ID="Button1" runat="server" OnClick="login" Text="log in" />
        <p>
            Register as:</p>
        <p>
            <asp:Button ID="Button2" runat="server" Text="Fan" OnClick="fanRegister" />
            <asp:Button ID="Button3" runat="server" Text="Sports Association Manager" OnClick="samRegister" />
            <asp:Button ID="Button4" runat="server" Text="Stadium Manager" OnClick="stadmanagerRegister" />
            <asp:Button ID="Button5" runat="server" Text="Club Representative" OnClick="clubrepRegister" />
        </p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
