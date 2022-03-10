<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderList.aspx.cs" Inherits="_1_List" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div align="center">
            <asp:Button ID="btn_order_del" runat="server" Text="Delete Order" OnClick="btn_order_del_Click" />
            <asp:Button ID="btn_order_add" runat="server" Text="Enter Order" OnClick="btn_order_add_Click"/>
            <asp:Button ID="btn_order_list" runat="server" Text="List Orders" OnClick="btn_order_list_Click" Enabled="False" />
            <asp:Button ID="btn_order_view" runat="server" Text="View Order" OnClick="btn_order_view_Click" />
        </div>
        <div>
            
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Id], [OrderTotal], [Description], [TotalItems], [DatePlaced], [Fulfilment] FROM [tblOrder]"></asp:SqlDataSource>
            <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" Height="227px" Width="1054px"></asp:GridView>
        </div>
    </form>
</body>
</html>
