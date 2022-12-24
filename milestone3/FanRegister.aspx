<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FanRegister.aspx.cs" Inherits="milestone3.FanRegister" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            Register as Fan</p>
        <p>
            Name:&nbsp;&nbsp;
            <asp:TextBox ID="fanNameTxt" runat="server" Height="16px" Width="181px"></asp:TextBox>
        </p>
        <p>
            Username:&nbsp;&nbsp;
            <asp:TextBox ID="fanUsernameTxt" runat="server" Width="154px"></asp:TextBox>
        </p>
        <p>
            Password:&nbsp;&nbsp;
            <asp:TextBox ID="fanPassTxt" runat="server" Width="154px"></asp:TextBox>
        </p>
        <p>
            National ID:&nbsp;&nbsp;
            <asp:TextBox ID="nationalIdTxt" runat="server" Width="143px"></asp:TextBox>
        </p>
        <p>
            Date of Birth:&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
        </p>
        <p>
            Address:&nbsp;&nbsp;
            <asp:TextBox ID="addressTxt" runat="server" Width="159px"></asp:TextBox>
        </p>
        <p>
            Phone Number:&nbsp;&nbsp;
            <asp:TextBox ID="phoneNumberTxt" runat="server" Width="150px"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" Text="Register" OnClick="fanReg" />
        </p>
    </form>
</body>
</html>
