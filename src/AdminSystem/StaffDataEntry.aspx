<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StaffDataEntry.aspx.cs" Inherits="_1_DataEntry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="lblEmpID" runat="server" Text="Employee ID  " width="250px"></asp:Label>
        <asp:TextBox ID="intEmpID" runat="server" OnTextChanged="intEmpID_TextChanged"></asp:TextBox>
        <p>
            <asp:Label ID="lblEmpFullName" runat="server" Text="Employee FullName  " width="250px"></asp:Label>
            <asp:TextBox ID="txtEmpFullName" runat="server"></asp:TextBox>
        </p>
        <asp:Label ID="lblSalary" runat="server" Text="Salary  " width="250px"></asp:Label>
        <asp:TextBox ID="doubleSalary" runat="server"></asp:TextBox>
        <p>
            <asp:Label ID="lblJobDescPerm" runat="server" Text="Job Description / Permissions " width="250px"></asp:Label>
            <asp:TextBox ID="txtJobDescPerm" runat="server"></asp:TextBox>
        </p>
        <asp:Label ID="lblDateHired" runat="server" Text="Date Of Hiring  " width="250px"></asp:Label>
        <asp:TextBox ID="dateTimeHiringDate" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:CheckBox ID="chkActive" runat="server" Text="Active" />
        <p>
            <asp:Label ID="lblError" runat="server"></asp:Label>
        </p>
        <asp:Button ID="btnOK" runat="server" OnClick="btnOK_Click" Text="Okay" Width="57px" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
    </form>
</body>
</html>
