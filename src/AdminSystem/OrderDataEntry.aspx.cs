using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

public partial class _1_DataEntry : System.Web.UI.Page
{
    /// <summary>
    /// Private class field mID
    /// Stores the order as a signed 32-bit integer value
    /// </summary>
    Int32 mID;

    protected void Page_Load(object sender, EventArgs e)
    {
        //getting the number of the staff member to be processed
        mID = Convert.ToInt32(Session["mID"]);
        if (IsPostBack == false)
        {
            //if this is not a new record
            if (mID != -1)
            {
                //displaying the current data for the record
                DisplayOrderInfo();
            }
        }
    }

    private void DisplayOrderInfo()
    {
        //creating an instance of the staff collection
        clsOrderCollection OrderBooks = new clsOrderCollection();
        //finding the record to update
        OrderBooks.ThisOrder.Find(mID);
        //Displaying the data for this record
        intOrderID.Text = Convert.ToString(OrderBooks.ThisOrder.mID);
        txtOrderDesc.Text = OrderBooks.ThisOrder.Description;
        dblCost.Text = Convert.ToString(OrderBooks.ThisOrder.TotalCost);
        txtTotalItems.Text = Convert.ToString(OrderBooks.ThisOrder.TotalItems);
        txtDatePlaced.Text = Convert.ToString(OrderBooks.ThisOrder.DatePlaced);
        chkFulfilled.Checked = OrderBooks.ThisOrder.Fulfillment_status;
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

    protected void intOrderID_TextChanged(object sender, EventArgs e)
    {
        clsOrder vOrder = new clsOrder();
        vOrder.Validate(txtOrderDesc.Text, dblCost.Text, txtTotalItems.Text, txtDatePlaced.Text);
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        Add();
    }

    private void Add()
    {
        //create a new instance of clsOrder
        clsOrder mOrder = new clsOrder();
        //capture the Employee Name
        string desc = txtOrderDesc.Text;
        //capture Salary
        string tCost = dblCost.Text;
        //capture Job Description and permissions
        string totalItems= txtTotalItems.Text;
        //capture the date Hired
        string datePlaced = txtDatePlaced.Text;
        // variable to store any error message
        string Error = "";
        //validate the data 
        Error = mOrder.Validate(desc, tCost, totalItems, datePlaced);
        if (Error == "")
        {
            try
            {
                // order ID data entry, parsed from a string
                mOrder.ID = Int32.Parse(intOrderID.Text);
                // order description data entry
                mOrder.Description = txtOrderDesc.Text;
                // 
                mOrder.TotalCost = Decimal.Parse(dblCost.Text);
                //capture the job description and permissions
                mOrder.TotalItems = Int32.Parse(txtTotalItems.Text);
                //capture the date hired
                mOrder.DatePlaced = DateTime.Parse(txtDatePlaced.Text);
                //capture active
                mOrder.Fulfillment_status = chkFulfilled.Checked;
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

            //create a new instance of the staff collection
            clsOrderCollection OrderList = new clsOrderCollection();

            //if this is a new record i.e. EmployeeId = -1 then add the data 
            if (mID == -1)
            {
                //set the ThisStaff property
                OrderList.ThisOrder = mOrder;
                //Adding the new record
                OrderList.Add();
            }
            //otherwise it must be an update
            else
            {
                //find the record to update 
                OrderList.ThisOrder.Find(mID);
                //setting thisStaff properties
                OrderList.ThisOrder = mOrder;
                //updating the record
                OrderList.Update();
            }
            //redirect back to the listpage
            Response.Redirect("StaffList.aspx");
        }
        else
        {
            //display the error message
            lblError.Text = Error;
        }
    }

    private void Find()
    {
        //create an instance of the class 
        clsOrder mOrder = new clsOrder();
        //variable to store the primary key value, representing the Order ID
        Int32 mID;
        //variable to store the result of the find operation
        Boolean Found = false;
        //get the primary key entered by the user
        mID = Convert.ToInt32(intOrderID.Text);
        //find the record 
        Found = mOrder.Find(mID);

        //if found
        if (Found == true)
        {
            //Display the values of the properties in the form
            txtEmpFullName.Text = mOrder.EmpFullName;
            doubleSalary.Text = Convert.ToString(mOrder.Salary);
            txtJobDescPerm.Text = mOrder.JobDescriptionPermissions;
            dateTimeHiringDate.Text = Convert.ToString(mOrder.DateHired);
            chkActive.Checked = mOrder.Active;
        }
        else
        {
            //Store the fullName in the session object
            Session["mOrder"] = mOrder;
            //navigate to the viewer page
            Response.Redirect("StaffViewer.aspx");
        }
    }

    protected void btnFind_Click(object sender, EventArgs e)
    {
        Find();
    }

    protected void txtOrderDesc_TextChanged(object sender, EventArgs e)
    {

    }

    protected void datePlaced_TextChanged(object sender, EventArgs e)
    {

    }
}