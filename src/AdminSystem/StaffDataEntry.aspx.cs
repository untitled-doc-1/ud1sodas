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
        
        try
        {
            AStaff.EmpFullName = txtEmpFullName.Text;
            AStaff.Active = chkActive.Checked;
            AStaff.JobDescriptionPermissions = txtJobDescPerm.Text;
            AStaff.EmployeeIDPrimary = Int32.Parse(intEmpID.Text);
            AStaff.Salary = Double.Parse(doubleSalary.Text);
            AStaff.DateHired = DateTime.Parse(dateTimeHiringDate.Text);
        } catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
        
        //Store the fullName in the session object
        Session["AStaff"]= AStaff;
        //navigate to the viewer page
        Response.Redirect("StaffViewer.aspx");


    }

    protected void txtEmpFullName_TextChanged(object sender, EventArgs e)
    {

    }
}