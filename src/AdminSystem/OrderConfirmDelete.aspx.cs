using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;
using System.Data.Sql;

public partial class _1_ConfirmDelete : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
    }

    protected void btn_order_del_Click(object sender, EventArgs e)
    {
        
    }

    protected void btn_order_add_Click(object sender, EventArgs e)
    {
        Response.Redirect("OrderDataEntry.aspx");
    }

    protected void btn_order_list_Click(object sender, EventArgs e)
    {
        Response.Redirect("OrderList.aspx");
    }

    protected void btn_order_view_Click(object sender, EventArgs e)
    {
        Response.Redirect("OrderViewer.aspx");
    }
}