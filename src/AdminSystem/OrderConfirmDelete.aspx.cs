using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;
using System.Data.Sql;

public partial class _Order_ConfirmDelete : System.Web.UI.Page
{
    //variable to store the primary key value of the record to be deleted
    Int32 mID;
    //event handler for the load event
    protected void Page_Load(object sender, EventArgs e)
    {
        //getting the number of the staff to be deleted from the session object
        mID = Convert.ToInt32(Session["OrderID"]);
    }

    protected void btnYes_Click(object sender, EventArgs e)
    {
        //creating an instance of the Staff book class
        clsOrderCollection Orders = new clsOrderCollection();
        //finding the record to delete
        Orders.ThisOrder.Find(mID);
        //Deleting the record
        Orders.Delete();
        //redirecting back to the main page
        Response.Redirect("OrderList.aspx");
    }

    protected void btnNo_Click(object sender, EventArgs e)
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