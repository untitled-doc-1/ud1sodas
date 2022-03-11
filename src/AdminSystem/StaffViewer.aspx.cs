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
        //display employee name for this entry
        Response.Write(AStaff.EmpFullName + "<br />");
        //display Active status
        Response.Write(AStaff.Active + "<br />");
        //display Job Description and Permissions
        Response.Write(AStaff.JobDescriptionPermissions + "<br />");
        //display employee Id
        Response.Write(AStaff.EmployeeId + "<br />");
        //display Staff date of hiring
        Response.Write(AStaff.DateHired + "<br />");
        //display staff salary
        Response.Write(AStaff.Salary + "<br />");

    }
}