using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class clsOrderCollection
    {
        // Fields
        
        // List object of several Order objects
        private List<clsOrder> mOrdersList = new List<clsOrder>();
        
        // Object for this order
        private clsOrder mThisOrder = new clsOrder();

        // Constructor
        public clsOrderCollection()
        {
            // object for data connection 
            clsDataConnection DB = new clsDataConnection();
            // executing the stored procedure
            DB.Execute("sproc_tblOrder_SelectAll");
            // populating the array list with the data table
            PopulateArray(DB);
        }

        // Methods
        public List<clsOrder> OrdersList
        {
            get
            {
                // return the private field
                return mOrdersList;
            }
            set
            {
                // seting the private data field
                mOrdersList = value;
            }
        }

        public int Count
        {
            get
            {
                // Returns the number of elements in the private List
                return mOrdersList.Count;
            }

            // No set method needed because Count method is internal and not overridden
        }
        public clsOrder ThisOrder
        {
            get
            {
                // Returns the private Order object
                return mThisOrder;
            }

            set
            {
                // Set the private Order object to 'value'
                mThisOrder = value;
            }
        }

        public int Add()
        {
            // Adds a new record to the database based on the values of mThisOrder
            // connecting to the database 
            clsDataConnection DB = new clsDataConnection();
            // setting the parameters for the stored procedure
            DB.AddParameter("@EmpFullName", mThisOrder.EmpFullName);
            DB.AddParameter("@Salary", mThisOrder.Salary);
            DB.AddParameter("@DateHired", mThisOrder.DateHired);
            DB.AddParameter("@JobDescriptionPermissions", mThisOrder.JobDescriptionPermissions);
            DB.AddParameter("@Active", mThisOrder.Active);

            // executing the query returning the primary key value
            return DB.Execute("sproc_tblOrder_Insert");
        }

        public void Update()
        {
            // updating an existing record based on the values of thisSatff
            // connecting to the database
            clsDataConnection DB = new clsDataConnection();
            // Setting the parameters for the stored procedure
            DB.AddParameter("@OrderId", mThisOrder.ID);
            DB.AddParameter("@EmpFullName", mThisOrder.EmpFullName);
            DB.AddParameter("@Salary", mThisOrder.Salary);
            DB.AddParameter("@DateHired", mThisOrder.DateHired);
            DB.AddParameter("@JobDescriptionPermissions", mThisOrder.JobDescriptionPermissions);
            DB.AddParameter("@Active", mThisOrder.Active);
            // executing the update Stored procedure
            DB.Execute("sproc_tblOrder_Update");
        }

        public void Delete()
        {
            // deletes the record pointed to by ThisOrder
            // connecting to the database
            clsDataConnection DB = new clsDataConnection();
            // setting the parameters for the stored procedure
            DB.AddParameter("@OrderId", mThisOrder.ID);
            // executing the stored procedure
            DB.Execute("sproc_tblOrder_Delete");
        }

        public void ReportByEmpFullName(string EmpFullName)
        {
            // filters the records based on a full or partial Employee FullName
            // connecting to the database
            clsDataConnection DB = new clsDataConnection();
            // sending the EmpFullName parameter to the database
            DB.AddParameter("@EmpFullName", EmpFullName);
            // executing the stored procedure
            DB.Execute("sproc_tblOrder_FilterByEmpFullName");
            // populating the array list with the data table
            PopulateArray(DB);
        }

        public void ReportJobDescriptionPermissions(string JobDescriptionPermissions)
        {
            // filters the records based on a full or partial Employee FullName
            // connecting to the database
            clsDataConnection DB = new clsDataConnection();
            // sending the EmpFullName parameter to the database
            DB.AddParameter("@JobDescriptionPermissions", JobDescriptionPermissions);
            // executing the stored procedure
            DB.Execute("sproc_tblOrder_FilterByJobDescriptionPermissions");
            // populating the array list with the data table
            PopulateArray(DB);
        }



        void PopulateArray(clsDataConnection DB)
        {
            // populates the array list based on the data table in the parameter DB
            // var for the index
            Int32 Index = 0;
            // var to store the record count
            Int32 RecordCount;
            // getting the count of records
            RecordCount = DB.Count;
            // clearing the private array list
            mOrdersList = new List<clsOrder>();
            // While there are records to process
            while (Index < RecordCount)
            {
                // create a blank Order
                clsOrder bOrder = new clsOrder();
                // read in the fields from the current record
                bOrder.Active = Convert.ToBoolean(DB.DataTable.Rows[Index]["Active"]);
                bOrder.ID = Convert.ToInt32(DB.DataTable.Rows[Index]["OrderId"]);
                bOrder.EmpFullName = Convert.ToString(DB.DataTable.Rows[Index]["EmpFullName"]);
                bOrder.JobDescriptionPermissions = Convert.ToString(DB.DataTable.Rows[Index]["JobDescriptionPermissions"]);
                bOrder.Salary = Convert.ToDouble(DB.DataTable.Rows[Index]["Salary"]);
                bOrder.DateHired = Convert.ToDateTime(DB.DataTable.Rows[Index]["DateHired"]);
                // adding the record to the private data memeber
                mOrdersList.Add(bOrder);
                // pointing at the next record
                Index++;
            }
        }
    }
}