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
            AStaff.EmployeeId = Int32.Parse(intEmpID.Text);
            AStaff.EmpFullName = txtEmpFullName.Text;
            AStaff.Salary = Double.Parse(doubleSalary.Text);
            AStaff.JobDescriptionPermissions = txtJobDescPerm.Text;
            AStaff.DateHired = DateTime.Parse(dateTimeHiringDate.Text);
            AStaff.Active = chkActive.Checked;
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

    protected void btnFind_Click(object sender, EventArgs e)
    {
        
        //create an instance of the class 
        clsStaff AStaff = new clsStaff();
        //variable to store the primary key
        Int32 EmployeeId;
        //variable to store the result of the find operation
        Boolean Found = false;
        //get the primary key entered by the user
        EmployeeId = Convert.ToInt32(intEmpID.Text);
        //find the record 
        Found = AStaff.Find(EmployeeId);
        
        //if found
        if (Found == true)
        {
            //Display the values of the properties in the form
            txtEmpFullName.Text = AStaff.EmpFullName;
            doubleSalary.Text = Convert.ToString(AStaff.Salary);
            txtJobDescPerm.Text = AStaff.JobDescriptionPermissions;
            dateTimeHiringDate.Text = Convert.ToString(AStaff.DateHired);
            chkActive.Checked = AStaff.Active;
        }
        else
        {
            //Store the fullName in the session object
            Session["AStaff"] = AStaff;
            //navigate to the viewer page
            Response.Redirect("StaffViewer.aspx");
        }
    }
}