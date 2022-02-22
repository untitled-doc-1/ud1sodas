using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

public partial class _1Viewer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //create a new instance of a clsStaff
        clsStaff AStaff = new clsStaff();
        //get the data from the session object
        AStaff = (clsStaff)Session["Employee Name "];
        //display employee name for this entry
        Response.Write(AStaff.EmpFullName);
        //display Active status
        Response.Write(AStaff.Active);
        //display Job Description and Permissions
        Response.Write(AStaff.JobDescriptionPermissions);
        //display employee Id
        Response.Write(AStaff.EmployeeIDPrimary);
        //display Staff date of hiring
        Response.Write(AStaff.DateHired);
        //display staff salary
        Response.Write(AStaff.Salary);

    }
}