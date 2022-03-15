using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ClassLibrary
{
    public class clsStaff
    {
        //fields
        private Boolean mActive;
        private DateTime mDateHired;
        private Int32 mEmployeeId;
        private double mSalary;
        private String mEmpFullName;
        private String mJobDescriptionPermissions;


        //methods
        public bool Active
        {
            get
            {
                //returns private field mActive
                return mActive;
            }

            set
            {
                //sets private field mActive
                mActive = value;
            }
        }
        
        public DateTime DateHired
        {
            get
            {
                //returns the data out of the property
                return mDateHired;
            }
            set
            {
                //allows data into the property, set.
                mDateHired = value;
            }
        }
        
        public int EmployeeId
        {
            get
            {
                //this line sends data out of the property
                return mEmployeeId;
            }
            set
            {
                //this line allows data into the property
                mEmployeeId = value;
            }
        }

        public double Salary 
        {
            get 
            {
                //returns private field mSalary
                return mSalary;
            }
            set 
            {
                //set the value of private field mSalary
                mSalary = value;
            }
         }

        public string EmpFullName
        {
            get
            {
                //returns private field mEmpFullName
                return mEmpFullName;
            }
            set
            {
                //set the value of private field mEmpFullName
                mEmpFullName = value;
            }
        }
        public string JobDescriptionPermissions
        {
            get
            {
                //returns private field mJobDescriptionPermissions
                return mJobDescriptionPermissions;
            }
            set
            {
                //set the value of private field mJobDescriptionPermissions
                mJobDescriptionPermissions = value;
            }
        }

        public bool Find(int EmployeeId)
        {
            //creat an instance of the database connection
            clsDataConnection DB = new clsDataConnection();
            //adding the parameter for EmplyeeId to search for
            DB.AddParameter("@EmployeeId", EmployeeId);
            //execute the stored procedure
            DB.Execute("sproc_tblStaff_FilterByEmployeeId");
            //if one record is found (there should be either one or zero)
            if (DB.Count == 1)
            {
                mEmployeeId = Convert.ToInt32(DB.DataTable.Rows[0]["EmployeeId"]);
                mEmpFullName = Convert.ToString(DB.DataTable.Rows[0]["EmpFullName"]);
                mSalary = Convert.ToDouble(DB.DataTable.Rows[0]["Salary"]);
                mDateHired = Convert.ToDateTime(DB.DataTable.Rows[0]["DateHired"]);
                mJobDescriptionPermissions = Convert.ToString(DB.DataTable.Rows[0]["JobDescriptionPermissions"]);
                mActive = Convert.ToBoolean(DB.DataTable.Rows[0]["Active"]);
                //return that everything worked ok
                return true;
            }
            //else if record is not found
            else
            {
                //return false indicating an issue
                return false;
            }
        }

        public string Valid(string empFullName, string salary, string jobDescriptionPermissions, string dateHired)
        {
            //create a string variable to store the error 
            String Error = "";
            //temporatry variable to store date values
            DateTime DateTemp;

            //EmpFullName
            //if the EmpFullName is blank
            if (empFullName.Length == 0)
            {
                Error = Error + "The Employee Name should not be blank";
            }

            if(empFullName.Length > 50)
            {
                Error = Error + "The Employee Name you have entered is too long, Must be less Than 50 Char";
            }
            //JobDescriptionPermissions
            if (jobDescriptionPermissions.Length == 0)
            {
                Error = Error + "The Description should not be blank";
            }

            if (jobDescriptionPermissions.Length > 50)
            {
                Error = Error + "The Description you have entered is too long, Must be less Than 50 Char";
            }

            //DateHired
            //create a temp variable
            DateTemp = Convert.ToDateTime(DateHired);
            if (DateTemp < DateTime.Now.Date)
            {
                //record the error
                Error = Error + "The date cannot be in the past";
            }

            if (DateTemp > DateTime.Now.Date)
            {
                //Record the error
                Error = Error + "The date cannot be in the future";
            }
            //return an error message
            return Error;
        }
    }
}