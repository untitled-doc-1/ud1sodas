using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

public partial class _Order_Viewer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //create a new instance of a clsStaff
        clsOrder mOrder = new clsOrder();
        //get the data from the session object
        mOrder = (clsOrder)Session["mOrder"];

        // Set Order ID field
        txtID.Text = Convert.ToString(mOrder.ID);
        // Set Order description
        txtDesc.Text = mOrder.Description;
        // Set Order total items
        txtTotalItems.Text = mOrder.Description;
        // Set Order total cost
        txtTotalCost.Text = Convert.ToString(mOrder.TotalCost);
        // Set Order date placed field
        txtDatePlaced.Text = mOrder.DatePlaced.Date.ToString();
        // Set Order fulfilment status checkbox
        chkFulfilled.Checked = mOrder.Fulfillment_status;
    }

    protected void btn_order_del_Click(object sender, EventArgs e)
    {
        Response.Redirect("OrderConfirmDelete.aspx");
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

    }
}