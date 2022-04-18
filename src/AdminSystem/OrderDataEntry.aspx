<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderDataEntry.aspx.cs" Inherits="_Order_DataEntry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div align="center">
            <asp:Button ID="btn_order_del" runat="server" Text="Delete Order" OnClick="btn_order_del_Click" />
            <asp:Button ID="btn_order_add" runat="server" Text="Enter Order" Enabled="False" />
            <asp:Button ID="btn_order_list" runat="server" Text="List Orders" OnClick="btn_order_list_Click" />
            <asp:Button ID="btn_order_view" runat="server" Text="View Order" OnClick="btn_order_view_Click" />
            <br />
            <br />
        </div>

        <asp:Label ID="lblOrderID" runat="server" Text="Order ID" Width="250px"></asp:Label>
        <asp:TextBox ID="intOrderID" runat="server"></asp:TextBox>
        <p>
            <asp:Label ID="lblOrderDesc" runat="server" Text="Order Description" Width="250px"></asp:Label>
            <asp:TextBox ID="txtOrderDesc" runat="server"></asp:TextBox>
        </p>
        <asp:Label ID="lblCost" runat="server" Text="Total Cost" Width="250px"></asp:Label>
        <asp:TextBox ID="txtTotalCost" runat="server"></asp:TextBox>
        <p>
            <asp:Label ID="lblTotalItems" runat="server" Text="Total Items" Width="250px"></asp:Label>
            <asp:TextBox ID="txtTotalItems" runat="server"></asp:TextBox>
        </p>
        <asp:Label ID="lblDatePlaced" runat="server" Text="Date of order being placed" Width="250px"></asp:Label>
        <asp:TextBox ID="txtDatePlaced" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:CheckBox ID="chkFulfilled" runat="server" Text="Fulfilled?" />
        <p>
            <asp:Label ID="lblError" runat="server"></asp:Label>
        </p>
        <asp:Button ID="btnOK" runat="server" OnClick="btnOK_Click" Text="Okay" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
        <asp:Button ID="btnFind" runat="server" OnClick="btnFind_Click" Text="Find" />
    </form>
</body>
</html>
