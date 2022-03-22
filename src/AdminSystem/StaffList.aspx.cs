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
}