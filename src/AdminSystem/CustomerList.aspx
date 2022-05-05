<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomerList.aspx.cs" Inherits="_1_List" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            height: 690px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ListBox ID="lstCustomerList" runat="server" Height="541px" Width="682px"></asp:ListBox>
        </div>
        <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add" />
        <asp:Button ID="btnEdit" runat="server" OnClick="btnEdit_Click" Text="Edit" />
        <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete" />

        <div>
            <p>
                <asp:Label ID="lblEmail" runat="server" Text="Enter an email address"></asp:Label></p>
            <asp:TextBox ID="textEmail" runat="server"></asp:TextBox>
            <p>
                <asp:Button ID="btnApply" runat="server" Text="Apply" OnClick="btnApply_Click" />
                <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />
            </p>

        </div>
    </form>
    <p>
        <asp:Label ID="lblError" runat="server" Text="Error message"></asp:Label>
    </p>
</body>
</html>
