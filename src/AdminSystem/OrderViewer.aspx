<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderViewer.aspx.cs" Inherits="_Order_Viewer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div align="center">
            <asp:Button ID="btn_order_del" runat="server" Text="Delete Order" OnClick="btn_order_del_Click" /><asp:Button ID="btn_order_add" runat="server" Text="Enter Order" OnClick="btn_order_add_Click" /><asp:Button ID="btn_order_list" runat="server" Text="List Orders" OnClick="btn_order_list_Click" /><asp:Button ID="btn_order_view" runat="server" Text="View Order" Enabled="False" OnClick="btn_order_view_Click" />
        </div>
        <div style="margin-left: 40px">
            <asp:Label ID="lblID" runat="server" Text="Order ID:" Width="200px"></asp:Label>
            <asp:Label ID="txtID" runat="server" ></asp:Label>
            <br />

            <asp:Label ID="lblDesc" runat="server" Text="Order Description:" Width="200px"></asp:Label>
            <asp:Label ID="txtDesc" runat="server" ></asp:Label>
            <br />

            <asp:Label ID="lblTotalCost" runat="server" Text="Order cost total:" Width="200px"></asp:Label>
            <asp:Label ID="txtTotalCost" runat="server" ></asp:Label>
            <br />

            <asp:Label ID="lblTotalItems" runat="server" Text="Order item total:" Width="200px"></asp:Label>
            <asp:Label ID="txtTotalItems" runat="server" ></asp:Label>
            <br />

            <asp:Label ID="lblDatePlaced" runat="server" Text="Order date:" Width="200px"></asp:Label>
            <asp:Label ID="txtDatePlaced" runat="server" ></asp:Label>
            <br />

            <asp:Label ID="lblFulfilled" runat="server" Text="Order fulfilled?:" Width="200px"></asp:Label>
            <asp:CheckBox ID="chkFulfilled" runat="server" Enabled="false"/>

        </div>
    </form>
</body>
</html>
