﻿using System;
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
        string EmpFullName = txtEmpFullName.Text;
        //capture Salary
        string Salary = doubleSalary.Text;
        //capture Job Description and permissions
        string JobDescriptionPermissions = txtJobDescPerm.Text;
        //capture the date Hired
        string DateHired = dateTimeHiringDate.Text;
        // variable to store any error message
        string Error = "";
        //validate the data 
        Error = AStaff.Valid( EmpFullName, Salary, JobDescriptionPermissions, DateHired);
        if (Error == "")
        {
            try
            {
                //capture the Employee Id
                AStaff.EmployeeId = Int32.Parse(intEmpID.Text);
                //capture the Employee full name
                AStaff.EmpFullName = txtEmpFullName.Text;
                //capture the salary
                AStaff.Salary = Double.Parse(doubleSalary.Text);
                //capture the job description and permissions
                AStaff.JobDescriptionPermissions = txtJobDescPerm.Text;
                //capture the date hired
                AStaff.DateHired = DateTime.Parse(dateTimeHiringDate.Text);
                //capture active
                AStaff.Active = chkActive.Checked;
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

            //create a new instance of the staff collection
            clsStaffCollection StaffList = new clsStaffCollection();
            //set the ThisStaff property
            StaffList.ThisStaff = AStaff;
            //Adding the new record
            StaffList.Add();
            //redirect back to the listpage
            Response.Redirect("StaffList.aspx");
        }
        else
        {
            //display the error message
            lblError.Text = Error;
        }

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