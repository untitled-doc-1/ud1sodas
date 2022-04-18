<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderList.aspx.cs" Inherits="_Order_List" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div align="center">
            <asp:Button ID="btn_order_del" runat="server" Text="Delete Order" OnClick="btn_order_del_Click" />
            <asp:Button ID="btn_order_add" runat="server" Text="Enter Order" OnClick="btn_order_add_Click" />
            <asp:Button ID="btn_order_list" runat="server" Text="List Orders" Enabled="False" />
            <asp:Button ID="btn_order_view" runat="server" Text="View Order" OnClick="btn_order_view_Click" />
        </div>


        <asp:ListBox ID="lstOrderList" runat="server" Height="280px" Width="350px"></asp:ListBox>
        <p>
            <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add" />
            <asp:Button ID="btnEdit" runat="server" OnClick="btnEdit_Click" Text="Edit" />
            <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete" />
        </p>
        <p>
            Filtering Search:
        </p>
        <p>
            Enter a Description
            <asp:TextBox ID="descFilter" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="btnApply" runat="server" OnClick="btnApply_Click" Text="Apply" />
            <asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" Text="Clear" />
        </p>
        <asp:Label ID="lblError" runat="server" Text="[lblError]"></asp:Label>
    </form>
</body>
</html>
