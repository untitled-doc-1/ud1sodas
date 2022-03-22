using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class clsStaffCollection
    {
        //fields
        //private data memebr for the list
        List<clsStaff> mStaffList = new List<clsStaff>();

        //constructors
        public clsStaffCollection()
        {
            //var for the index
            Int32 Index = 0;
            //var to store the record count
            Int32 RecordCount = 0;
            //object for data connection
            clsDataConnection DB = new clsDataConnection();
            //execute the stored procedure Select All
            DB.Execute("sproc_tblStaff_SelectAll");
            //get the count of records
            RecordCount = DB.Count;
            //While there are records to process
            while (Index < RecordCount)
            {
                //create a blank Staff
                clsStaff AStaff = new clsStaff();
                //read in the fields from the current record
                AStaff.Active = Convert.ToBoolean(DB.DataTable.Rows[Index]["Active"]);
                AStaff.EmployeeId = Convert.ToInt32(DB.DataTable.Rows[Index]["EmployeeId"]);
                AStaff.EmpFullName = Convert.ToString(DB.DataTable.Rows[Index]["EmpFullName"]);
                AStaff.JobDescriptionPermissions = Convert.ToString(DB.DataTable.Rows[Index]["JobDescriptionPermissions"]);
                AStaff.Salary = Convert.ToDouble(DB.DataTable.Rows[Index]["Salary"]);
                AStaff.DateHired = Convert.ToDateTime(DB.DataTable.Rows[Index]["DateHired"]);
                //adding the record to the private data memeber
                mStaffList.Add(AStaff);
                //pointing at the next record
                Index++;
            }
        }

        //methods
        public List<clsStaff> StaffList
        {
            get
            {
                //return the private field
                return mStaffList;
            }
            set
            {
                //seting the private data field
                mStaffList = value;
            }
        }

        public int Count
        {
            get
            {
                //return the count of the private list
                return mStaffList.Count;
            }
            set
            {
                //for later
            }
        }
        public clsStaff ThisStaff { get; set; }
    }
}