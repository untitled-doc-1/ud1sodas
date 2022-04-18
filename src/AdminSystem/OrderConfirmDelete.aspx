<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderConfirmDelete.aspx.cs" Inherits="_Order_ConfirmDelete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div align="center">
            <asp:Button ID="btn_order_del" runat="server" Text="Delete Order" OnClick="btn_order_del_Click" Enabled="False" />
            <asp:Button ID="btn_order_add" runat="server" Text="Enter Order" OnClick="btn_order_add_Click" />
            <asp:Button ID="btn_order_list" runat="server" Text="List Orders" OnClick="btn_order_list_Click" />
            <asp:Button ID="btn_order_view" runat="server" Text="View Order" OnClick="btn_order_view_Click" />
        </div>
        <div>
            Are you sure you want to delete this record?<br />
            <br />
            <asp:Button ID="btnYes" runat="server" OnClick="btnYes_Click" Text="Yes" />
            <asp:Button ID="btnNo" runat="server" OnClick="btnNo_Click" Text="No" />
        </div>
    </form>
</body>
</html>
