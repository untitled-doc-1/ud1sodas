using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

public partial class _1_ConfirmDelete : System.Web.UI.Page
{
    //variable to store the primary key value of the record to be deleted
    Int32 EmployeeId;
    //event handler for the load event
    protected void Page_Load(object sender, EventArgs e)
    {
        //getting the number of the staff to be deleted from the session object
        EmployeeId = Convert.ToInt32(Session["EmployeeId"]);
    }

    protected void btnYes_Click(object sender, EventArgs e)
    {
        //creating an instance of the Staff book class
        clsStaffCollection StaffBook = new clsStaffCollection();
        //finding the record to delete
        StaffBook.ThisStaff.Find(EmployeeId);
        //Deleting the record
        StaffBook.Delete();
        //redirecting back to the main page
        Response.Redirect("StaffList.aspx");
    }

    protected void btnNo_Click(object sender, EventArgs e)
    {

    }
}