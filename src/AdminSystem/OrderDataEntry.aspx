<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderDataEntry.aspx.cs" Inherits="_1_DataEntry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div align="center">
            <asp:Button ID="btn_order_del" runat="server" Text="Delete Order" OnClick="btn_order_del_Click" />
            <asp:Button ID="btn_order_add" runat="server" Text="Enter Order" OnClick="btn_order_add_Click" Enabled="False" />
            <asp:Button ID="btn_order_list" runat="server" Text="List Orders" OnClick="btn_order_list_Click" />
            <asp:Button ID="btn_order_view" runat="server" Text="View Order" OnClick="btn_order_view_Click" />
        </div>
        <div>
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
        </div>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    </form>
</body>
</html>
