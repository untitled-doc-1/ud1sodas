<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomerDataEntry.aspx.cs" Inherits="_1_DataEntry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 659px">
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="lblCustomerName" runat="server" Text="Full Name"></asp:Label>
        <p>
            <asp:TextBox ID="textCustomerName" runat="server"></asp:TextBox>
        </p>
        <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
        <p>
            <asp:TextBox ID="textEmail" runat="server"></asp:TextBox>
        </p>

        <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
        <p>
            <asp:TextBox ID="textPassword" runat="server"></asp:TextBox>
        </p>

        <asp:Label ID="LblAddress" runat="server" Text="Address"></asp:Label>
        <p>
            <asp:TextBox ID="textAddress" runat="server"></asp:TextBox>
        </p>
        <asp:Label ID="lblPhoneNumber" runat="server" Text="Phone Number"></asp:Label>
        <p>
            <asp:TextBox ID="textPhoneNumer" runat="server" style="margin-bottom: 8px"></asp:TextBox>
        </p>
        <asp:Label ID="lblSignedUp" runat="server" Text="Signed Up"></asp:Label>
        <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
        <asp:CheckBox ID="chkActive" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged" Text="Disabled" />

        <asp:Button ID="btnOK" runat="server" Text="OK" OnClick="btnOK_Click" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
    </form>
</body>
</html>
