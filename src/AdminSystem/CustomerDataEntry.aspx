<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomerDataEntry.aspx.cs" Inherits="_1_DataEntry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 782px">
    <form id="form1" runat="server">
        <div>
        <asp:Label ID="lblCustomerID" runat="server" Text="Customer ID"></asp:Label>
        <p>
            <asp:TextBox ID="textCustomerId" runat="server"></asp:TextBox>
            <asp:Button ID="btnFindCustomer" runat="server" Text="Find" OnClick="btnFindCustomer_Click" />
        </p>
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

        <asp:Label ID="LblAddressLine1" runat="server" Text="AddressLine1"></asp:Label>
        <p>
            <asp:TextBox ID="textAddressLine1" runat="server"></asp:TextBox>
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
