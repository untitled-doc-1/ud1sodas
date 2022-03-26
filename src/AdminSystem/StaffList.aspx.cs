using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

public partial class _1_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if this is the first time the page is displayed
        if(IsPostBack == false)
        {
            //update the list box
            DisplayStaffMembers();
        }
    }

    void DisplayStaffMembers()
    {
        //creating an instanse of the class collection
        clsStaffCollection StaffMembers = new clsStaffCollection();
        //setting the data source to list of Staffmembers in the collection
        lstStaffList.DataSource = StaffMembers.StaffList;
        //setting the name of the primary key
        lstStaffList.DataValueField = "EmployeeId";
        //setting the data field to display
        lstStaffList.DataTextField = "EmpFullName";
        //binding the data to the list
        lstStaffList.DataBind();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        //Store -1 into the session object to indicate this is a new record 
        Session["EmployeeId"] = -1;
        //redirect to the data entry page
        Response.Redirect("StaffDataEntry.aspx");
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        //variable to store the primary key value of the record to be edited
        Int32 EmployeeId;
        //if a record has been selected from the list
        if (lstStaffList.SelectedIndex != -1)
        {
            //getting the primary key value of the record to edit
            EmployeeId = Convert.ToInt32(lstStaffList.SelectedValue);
            //Storing the data in the session object
            Session["EmployeeId"] = EmployeeId;
            //Redirecting to the edit page
            Response.Redirect("StaffDataEntry.aspx");
        }
        //if no record has been selected
        else
        {
            lblError.Text = "Please select a record to edit from the list";
        }
    }
}