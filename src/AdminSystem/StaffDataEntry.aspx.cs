using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

public partial class _1_DataEntry : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void intEmpID_TextChanged(object sender, EventArgs e)
    {

    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        //create a new instance of clsStaff
        clsStaff AStaff = new clsStaff();
        //capture the Employee Name
        AStaff.EmpFullName = txtEmpFullName.Text;
        AStaff.Active = chkActive.Checked;
        AStaff.JobDescription = txtJobDesc.Text;
        AStaff.Permissions = txtPermissions.Text;
        //AStaff.EmployeeIDPrimary = Int32.Parse(intEmpID);
        //AStaff.Salary = doubleSalary.Text;
        //AStaff.DateHired = dateTimeHiringDate.Text;
        //Store the fullName in the session object
        Session["AStaff"]= AStaff;
        //navigate to the viewer page
        Response.Redirect("StaffViewer.aspx");


    }
}