<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sports_Association.aspx.cs" Inherits="milestone3.Sports_Association" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style2 {
            width: 146px;
        }
        .auto-style3 {
            width: 146px;
            height: 29px;
        }
        .auto-style4 {
            height: 29px;
        }
    </style>
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
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Milestone2#1ConnectionString %>" SelectCommand="SELECT [name] FROM [Club]"></asp:SqlDataSource>
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
                <br />
                <br />
                <table style="width:100%;">
                    <tr>
                        <td class="auto-style2">
                            <asp:Label ID="Label6" runat="server" Text="Host club"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownList4" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource2" DataTextField="name" DataValueField="name">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Milestone2#1ConnectionString %>" SelectCommand="SELECT [name] FROM [Club]"></asp:SqlDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style3">
                            <asp:Label ID="Label7" runat="server" Text="Guest club"></asp:Label>
                        </td>
                        <td class="auto-style4">
                            <asp:DropDownList ID="DropDownList5" runat="server" DataSourceID="SqlDataSource2" DataTextField="name" DataValueField="name">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style3">
                            <asp:Label ID="Label8" runat="server" Text="Start time"></asp:Label>
                        </td>
                        <td class="auto-style4">
                            <asp:TextBox ID="TextBox1" runat="server" type="datetime-local"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style3">End time</td>
                        <td class="auto-style4">
                            <asp:TextBox ID="TextBox2" runat="server" type="datetime-local"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <asp:Button ID="Button2" runat="server" Text="Delete match" OnClick="deleteMatch" />
                <br />
            </asp:View>
            <asp:View ID="View3" runat="server">
                <br />
                <br />
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource3">
                    <Columns>
                        <asp:BoundField DataField="host" HeaderText="host" SortExpression="host" />
                        <asp:BoundField DataField="guest" HeaderText="guest" SortExpression="guest" />
                        <asp:BoundField DataField="start_time" HeaderText="start_time" SortExpression="start_time" />
                        <asp:BoundField DataField="end_time" HeaderText="end_time" SortExpression="end_time" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Milestone2#1ConnectionString %>" SelectCommand="select c1.name host,c2.name guest,start_time,end_time from match inner join club c1 on match.host_id=c1.id 
inner join club c2 on c2.id=visitor_id
where CURRENT_TIMESTAMP&lt;start_time"></asp:SqlDataSource>
            </asp:View>
            <asp:View ID="View4" runat="server">
                <br />
                <br />
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource4">
                    <Columns>
                        <asp:BoundField DataField="host" HeaderText="host" SortExpression="host" />
                        <asp:BoundField DataField="guest" HeaderText="guest" SortExpression="guest" />
                        <asp:BoundField DataField="start_time" HeaderText="start_time" SortExpression="start_time" />
                        <asp:BoundField DataField="end_time" HeaderText="end_time" SortExpression="end_time" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:Milestone2#1ConnectionString %>" SelectCommand="select c1.name host,c2.name guest,start_time,end_time from match inner join club c1 on match.host_id=c1.id 
inner join club c2 on c2.id=visitor_id
where CURRENT_TIMESTAMP&gt;end_time"></asp:SqlDataSource>
            </asp:View>
            <asp:View ID="View5" runat="server">
                <br />
                <br />
                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource5">
                    <Columns>
                        <asp:BoundField DataField="club1" HeaderText="club1" SortExpression="club1" />
                        <asp:BoundField DataField="club2" HeaderText="club2" SortExpression="club2" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:Milestone2#1ConnectionString %>" SelectCommand="select c1.name club1  , c2.name club2 from Club c1 inner join Club c2 on c1.id&gt;c2.id
where c2.id not in (select m.visitor_id from match m where c1.id=m.host_id )
and c2.id not in (select m2.host_id from match m2 where c1.id=m2.visitor_id)"></asp:SqlDataSource>
            </asp:View>
        </asp:MultiView>
    </form>
</body>
</html>
