using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;
using System.Diagnostics;


public partial class _Order_DataEntry : System.Web.UI.Page
{
    /// <summary>
    /// Private class field mID
    /// Stores the order as a signed 32-bit integer value
    /// </summary>
    Int32 mID;

    protected void Page_Load(object sender, EventArgs e)
    {
        mID = Convert.ToInt32(Session["OrderID"]);
        if (IsPostBack == false)
        {
            //if this is not a new record
            if (mID != -1)
            {
                //displaying the current data for the record
                Debug.WriteLine("DisplayOrder()");
                Debug.WriteLine("Order ID = " + mID);
                DisplayOrder();
            }
        }
    }

    protected void btn_order_del_Click(object sender, EventArgs e)
    {
        Response.Redirect("OrderConfirmDelete.aspx");
    }
    protected void btn_order_list_Click(object sender, EventArgs e)
    {
        Response.Redirect("OrderList.aspx");
    }

    protected void btn_order_view_Click(object sender, EventArgs e)
    {
        Response.Redirect("OrderViewer.aspx");
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        Add();
    }

    protected void btnFind_Click(object sender, EventArgs e)
    {
        Debug.WriteLine("DataEntry.Find()");
        Find();
    }


    private void Add()
    {
        //create a new instance of clsOrder
        clsOrder aOrder = new clsOrder();
        //capture the description
        string desc = txtOrderDesc.Text;
        //capture order cost
        string totalCost = txtTotalCost.Text;
        //capture order quantity
        string totalItems = txtTotalItems.Text;
        //capture the date placed
        string DatePlaced = txtDatePlaced.Text;
        // variable to store any error message
        string Error = "";
        //validate the data 
        Error = aOrder.Validate(desc, totalCost, totalItems, DatePlaced);
        if (Error == "")
        {
            try
            {
                // capture the Order ID
                aOrder.ID = Int32.Parse(intOrderID.Text);
                // capture the order description
                aOrder.Description = txtOrderDesc.Text;
                // capture the order cost
                aOrder.TotalCost = Decimal.Parse(txtTotalCost.Text);
                // capture the order quantity
                aOrder.TotalItems = Int32.Parse(txtTotalItems.Text);
                // capture the date placed
                aOrder.DatePlaced = DateTime.Parse(txtDatePlaced.Text).Date;
                // capture fulfillment
                aOrder.Fulfillment_status = chkFulfilled.Checked;
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

            // create a new instance of the OrderCollection class
            clsOrderCollection Orders = new clsOrderCollection();

            // if this is a new record i.e. OrderID = -1 then add the data 
            if (mID == -1)
            {
                // set the ThisOrder property
                Orders.ThisOrder = aOrder;
                // Adding the new record
                Orders.Add();
            }
            // otherwise it must be an update
            else
            {
                // find the record to update 
                Orders.ThisOrder.Find(mID);
                // set thisOrder to current object
                Orders.ThisOrder = aOrder;
                // updating the record
                Orders.Update();
            }
            // redirect back to the listpage
            Response.Redirect("OrderList.aspx");
        }
        else
        {
            // display the error message
            lblError.Text = Error;
        }

    }

    private void Find()
    {
        // create an instance of the class 
        clsOrder mOrder = new clsOrder();
        // variable to store the primary key value, representing the Order ID
        Int32 fID;
        // variable to store the result of the find operation
        Boolean Found = false;
        // get the primary key entered by the user
        fID = Convert.ToInt32(intOrderID.Text);
        // find the record 
        Found = mOrder.Find(fID);

        // if found
        if (Found == true)
        {
            // Display the values of the properties in the form
            txtOrderDesc.Text = mOrder.Description;
            txtTotalCost.Text = Convert.ToString(mOrder.TotalCost);
            txtTotalItems.Text = Convert.ToString(mOrder.TotalItems);
            txtDatePlaced.Text = Convert.ToString(mOrder.DatePlaced);
            chkFulfilled.Checked = mOrder.Fulfillment_status;
        }
        else
        {
            // Store the order in the session object
            Session["mOrder"] = mOrder;
            // navigate to the viewer page
            Response.Redirect("OrderViewer.aspx");
        }
    }

    private void DisplayOrder()
    {
        // creating an instance of the order collection
        clsOrderCollection OrderBooks = new clsOrderCollection();
        // finding the record to update
        OrderBooks.ThisOrder.Find(mID);
        // Displaying the data for this record
        intOrderID.Text = Convert.ToString(OrderBooks.ThisOrder.ID);
        txtOrderDesc.Text = OrderBooks.ThisOrder.Description;
        txtTotalCost.Text = Convert.ToString(OrderBooks.ThisOrder.TotalCost);
        txtTotalItems.Text = Convert.ToString(OrderBooks.ThisOrder.TotalItems);
        txtDatePlaced.Text = Convert.ToString(OrderBooks.ThisOrder.DatePlaced);
        chkFulfilled.Checked = OrderBooks.ThisOrder.Fulfillment_status;
    }
}