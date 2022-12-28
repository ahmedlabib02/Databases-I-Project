<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Stadium_manager.aspx.cs" Inherits="milestone3.Stadium_manager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style2 {
            height: 147px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <table style="width:100%;">
            <tr>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
                        <asp:ListItem>Select an action</asp:ListItem>
                        <asp:ListItem>View your info</asp:ListItem>
                        <asp:ListItem>View all requests</asp:ListItem>
                        <asp:ListItem>View unhandled requests</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:MultiView ID="MultiView1" runat="server">
                        <asp:View ID="View1" runat="server">
                            <asp:GridView ID="GridView1" runat="server">
                            </asp:GridView>
                        </asp:View>
                        <asp:View ID="View2" runat="server">
                            <br />
                            <asp:GridView ID="GridView2" runat="server">
                            </asp:GridView>
                        </asp:View>
                        <asp:View ID="View3" runat="server">
                            
                            <asp:GridView ID="GridView3" runat="server"  AutoGenerateColumns="False" OnRowCommand="GridView3_RowCommand"  >
                                <Columns>
                                    <asp:BoundField DataField="club_representative" HeaderText="Club representative " />
                                    <asp:BoundField DataField="host" HeaderText="Host club name" />
                                    <asp:BoundField DataField="guest" HeaderText="Guest club name" />
                                    <asp:BoundField DataField="start_time" HeaderText="Start time" />
                                    <asp:ButtonField CommandName="Accept" Text="Accept" />
                                    <asp:ButtonField CommandName="Reject" Text="Reject" />
                                </Columns>
                            </asp:GridView>
                            
                        </asp:View>
                    </asp:MultiView>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
