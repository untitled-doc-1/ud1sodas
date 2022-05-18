<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StockDataEntry.aspx.cs" Inherits="_1_DataEntry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            height: 376px;
            width: 199px;
        }
    </style>
</head>
<body style="width: 831px">
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="StockID" runat="server" Text="Stock ID" width="145px"></asp:Label>
        <asp:TextBox ID="txtStockID" runat="server" style="margin-bottom: 1px"></asp:TextBox>
        <asp:Label ID="StockSupplier" runat="server" Text="Stock Supplier" width="145px"></asp:Label>
        <asp:TextBox ID="txtStockSupplier" runat="server"></asp:TextBox>
        <asp:Label ID="StockAvailability" runat="server" Text="Stock Availability"></asp:Label>
        <asp:CheckBox ID="ChkStockAvailability" runat="server" Text="Available" />
        <asp:Label ID="DateArrived" runat="server" Text="Date Arrived" width="145px"></asp:Label>
        <asp:TextBox ID="txtDateArrived" runat="server" Width="152px"></asp:TextBox>
        <asp:Button ID="btnFind" runat="server" OnClick="btnFind_Click" Text="Find" />
        <asp:Label ID="StockDescription" runat="server" Text="Stock Description" width="145px"></asp:Label>
        <asp:TextBox ID="txtStockDescription" runat="server" style="margin-bottom: 5px"></asp:TextBox>
        <asp:Label ID="SupplierAddress" runat="server" Text="Supplier Address" width="145px"></asp:Label>
        <asp:TextBox ID="txtSupplierAddress" runat="server"></asp:TextBox>
        <asp:Label ID="lblError" runat="server"></asp:Label>
        <asp:Button ID="btnOK" runat="server" OnClick="btnOK_Click" Text="OK" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
    </form>
</body>
</html>
