using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

public partial class _Order_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // if this is the first time the page is displayed
        if (IsPostBack == false)
        {
            // update the list box
            DisplayOrderMembers();
        }
    }

    protected void btn_order_del_Click(object sender, EventArgs e)
    {
        Response.Redirect("OrderConfirmDelete.aspx");
    }

    protected void btn_order_add_Click(object sender, EventArgs e)
    {
        Response.Redirect("OrderDataEntry.aspx");
    }

    protected void btn_order_view_Click(object sender, EventArgs e)
    {
        Response.Redirect("OrderViewer.aspx");
    }

    void DisplayOrderMembers()
    {
        // creating an instanse of the class collection
        clsOrderCollection OrderMembers = new clsOrderCollection();
        // setting the data source to list of Ordermembers in the collection
        lstOrderList.DataSource = OrderMembers.OrdersList;
        // setting the name of the primary key
        lstOrderList.DataValueField = "ID";
        // setting the data field to display
        lstOrderList.DataTextField = "Description";
        // binding the data to the list
        lstOrderList.DataBind();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        // Store -1 into the session object to indicate this is a new record 
        Session["OrderID"] = -1;
        // redirect to the data entry page
        Response.Redirect("OrderDataEntry.aspx");
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        // variable to store the primary key value of the record to be edited
        Int32 OrderID;
        // if a record has been selected from the list
        if (lstOrderList.SelectedIndex != -1)
        {
            // getting the primary key value of the record to edit
            OrderID = Convert.ToInt32(lstOrderList.SelectedValue);
            // Storing the data in the session object
            Session["OrderID"] = OrderID;
            // Redirecting to the edit page
            Response.Redirect("OrderDataEntry.aspx");
        }
        //  In the event that no record has been selected
        else
        {
            lblError.Text = "Please select a record to edit from the list";
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        // A variable to store the primary key value of the record to be edited
        Int32 OrderID;
        // if the record has been selected from the list
        if (lstOrderList.SelectedIndex != -1)
        {
            // get the primary key value of the record to be edited
            OrderID = Convert.ToInt32(lstOrderList.SelectedValue);
            // Store the data in the session object
            Session["OrderID"] = OrderID;
            // redirect to the delete page
            Response.Redirect("OrderConfirmDelete.aspx");
        }
        // if no record is selected
        else
        {
            lblError.Text = "Please select an order to be deleted from the list";
        }
    }

    protected void btnApply_Click(object sender, EventArgs e)
    {
        // creating an instance of the class of the Order collection
        clsOrderCollection Orders = new clsOrderCollection();
        Orders.ReportByDescr(descFilter.Text);
        lstOrderList.DataSource = Orders.OrdersList;
        // setting the name of the primary key
        lstOrderList.DataValueField = "ID";
        // setting the name of the field to diplay
        lstOrderList.DataTextField = "Description";
        // binding the data to the list
        lstOrderList.DataBind();
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        // creating an instance of the class of the Order collection
        clsOrderCollection Orders = new clsOrderCollection();
        Orders.ReportByDescr("");
        // clearing any existing filter to tidy up the interface
        descFilter.Text = "";
        lstOrderList.DataSource = Orders.OrdersList;
        // setting the name of the primary key
        lstOrderList.DataValueField = "ID";
        // setting the name of the field to diplay
        lstOrderList.DataTextField = "Description";
        // binding the data to the list
        lstOrderList.DataBind();
    }
}