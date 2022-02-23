<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderConfirmDelete.aspx.cs" Inherits="_1_ConfirmDelete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Order ID to delete:
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            <br />
            Click OK to confirm deletion:
            <asp:Button ID="OKDelete" runat="server" OnClick="Button1_Click" Text="OK!" />
        </div>
    </form>
</body>
</html>
