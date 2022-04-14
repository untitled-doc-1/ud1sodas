using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{

    /*
        var server = "v00egd00001l.lec-admin.dmu.ac.uk";
        string db = "p2612742";
        string user = "p2612742";
        string pass = "Untitled5";
    */

    public class clsOrder
    {
        public int mID;
        private string mDescription;
        private int mTotalItems;
        private decimal mTotalCost;
        private bool mFulfillment_status = false;
        private DateTime mDatePlaced;

        public clsOrder()
        {

        }

        public int ID
        {
            get
            {
                return mID;
            }
            set
            {
                mID = value;
            }
        }

        public string Description
        {
            get
            {
                return mDescription;
            }
            set
            {
                mDescription = value;
            }
        }

        public decimal TotalCost
        {
            get
            {
                return mTotalCost;
            }
            set
            {
                mTotalCost = value;
            }
        }



        public int TotalItems
        {
            get
            {
                return mTotalItems;
            }
            set
            {
                mTotalItems = value;
            }
        }



        public DateTime DatePlaced
        {
            get
            {
                return mDatePlaced;
            }
            set
            {
                mDatePlaced = value;
            }
        }


        public bool Fulfillment_status
        {
            get
            {
                return mFulfillment_status;
            }
            set
            {
                mFulfillment_status = value;
            }

        }

        public bool Find(int OrderID)
        {
            // create an instance of the database connection
            clsDataConnection DB = new clsDataConnection();
            // adding the parameter for EmplyeeId to search for
            DB.AddParameter("@OrderId", OrderID);
            // execute the stored procedure
            DB.Execute("sproc_tblStaff_FilterByEmployeeId");
            // if a matching record is found (there should only be one exact match)
            if (DB.Count == 1)
            {
                mID = Convert.ToInt32(DB.DataTable.Rows[0]["OrderId"]);
                mDescription = Convert.ToString(DB.DataTable.Rows[0]["Description"]);
                mTotalCost = Convert.ToDecimal(DB.DataTable.Rows[0]["OrderTotal"]);
                mDatePlaced = Convert.ToDateTime(DB.DataTable.Rows[0]["DatePlaced"]);
                mTotalItems = Convert.ToInt32(DB.DataTable.Rows[0]["TotalItems"]);
                mFulfillment_status = Convert.ToBoolean(DB.DataTable.Rows[0]["Fulfilment"]);
                // return true if successful
                return true;
            }
            // if a matching record is not found
            else
            {
                // return false indicating an issue
                return false;
            }
        }

        public string Validate(string description, string totalCost, string totalItems, string datePlaced)
        {
            // create a string variable to store the error message string
            String Error = "";
            // temporatry variable to store date values
            DateTime TempDate;
            // temporary variable to store the salary
            Decimal TempCost;

            // Description
            // if the description field is blank
            if (description.Length == 0)
            {
                // Concatenate the error message string
                Error += "The Description should not be blank";
            }

            if (description.Length >= 50)
            {
                // Concatenate the error message string
                Error += "The Employee Name you have entered is too long, Must be less Than 50 Char";
            }

            // JobDescriptionPermissions
            if (totalItems.Length == 0)
            {
                // Concatenate the error message string
                Error += "The order cannot be empty";
            }

            // DatePlaced
            try
            {

                //create a temp variable
                TempDate = Convert.ToDateTime(datePlaced);
                if (TempDate < DateTime.Now.Date)
                {
                    // Concatenate the error message string
                    Error += "Invalid past date";
                }

                if (TempDate > DateTime.Now.Date)
                {
                    // Concatenate the error message string
                    Error += "Invalid future date";
                }
            }
            catch
            {
                // Concatenate the error message string
                Error += "The Date Was Not A Valid Date";
            }

            // TotalCost
            try
            {

                // Create a temporary variable
                TempCost = Convert.ToDecimal(totalCost);
                if (TempCost < 0)
                {
                    // Concatenate the error message string
                    Error += "The order's total cost cannot be below 0";
                }

                if (TempCost > 50000)
                {
                    // Concatenate the error message string 
                    Error += "The order's total cost cannot exceed 50000";
                }
            }
            catch
            {
                // Concatenate the error message string
                Error += "The data entered was not decimal";
            }
            // return the error message string
            return Error;
        }

    }
}