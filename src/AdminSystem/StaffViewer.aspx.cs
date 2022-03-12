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
        AStaff = (clsStaff)Session["AStaff"];
        //display employee Id
        Response.Write("EmployeeID = " + AStaff.EmployeeId + "<br />");
        //display employee name for this entry
        Response.Write("Employee FullName = " + AStaff.EmpFullName + "<br />");
        //display staff salary
        Response.Write("Salary = " + AStaff.Salary + "<br />");
        //display Job Description and Permissions
        Response.Write("Job Description & Permissions = " + AStaff.JobDescriptionPermissions + "<br />");
        //display Staff date of hiring
        Response.Write("Date Hired = " + AStaff.DateHired + "<br />");
        //display Active status
        Response.Write("Still Active = " + AStaff.Active + "<br />");

    }
}