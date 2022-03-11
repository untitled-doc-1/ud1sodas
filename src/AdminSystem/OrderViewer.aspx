<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderViewer.aspx.cs" Inherits="_1Viewer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div align="center">
            <asp:Button ID="btn_order_del" runat="server" Text="Delete Order" OnClick="btn_order_del_Click" /><asp:Button ID="btn_order_add" runat="server" Text="Enter Order" OnClick="btn_order_add_Click" /><asp:Button ID="btn_order_list" runat="server" Text="List Orders" OnClick="btn_order_list_Click" /><asp:Button ID="btn_order_view" runat="server" Text="View Order" Enabled="False" OnClick="btn_order_view_Click" />
        </div>
        <div>

            <asp:Label ID="Label1" runat="server" Text="Enter Order to list details: "></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="List order" />

        </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Description], [TotalItems], [OrderTotal], [DatePlaced], [Fulfilment] FROM [tblOrder] WHERE ([Id] = @Id)">
            <SelectParameters>
                <asp:ControlParameter ControlID="TextBox1" Name="Id" PropertyName="Text" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                <asp:BoundField DataField="TotalItems" HeaderText="TotalItems" SortExpression="TotalItems" />
                <asp:BoundField DataField="OrderTotal" HeaderText="OrderTotal" SortExpression="OrderTotal" />
                <asp:BoundField DataField="DatePlaced" HeaderText="DatePlaced" SortExpression="DatePlaced" />
                <asp:CheckBoxField DataField="Fulfilment" HeaderText="Fulfilment" SortExpression="Fulfilment" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
