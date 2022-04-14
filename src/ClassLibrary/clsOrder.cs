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
        // Private fields
        public int mID;
        private string mDescription;
        private int mTotalItems;
        private decimal mTotalCost;
        private bool mFulfillment_status = false;
        private DateTime mDatePlaced;

        /// <summary>
        /// Constructor for clsOrder object
        /// </summary>
        public clsOrder()
        {

        }

        /// <summary>
        /// public ID property with accessors
        /// </summary>
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

        /// <summary>
        /// public Description property with accessors
        /// </summary>
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

        /// <summary>
        /// public TotalCost property with accessors
        /// </summary>
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


        /// <summary>
        /// public TotalItems property with accessors
        /// </summary>
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

        /// <summary>
        /// public DatePlaced property with accessors
        /// </summary>
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


        /// <summary>
        /// public Fulfilment_status property with accessors
        /// </summary>
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

        /// <summary>
        /// Searches database for specific order with matching ID
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Validates the parameters passed to the method, with strings representing the different fields
        /// </summary>
        /// <param name="description"></param>
        /// <param name="totalCost"></param>
        /// <param name="totalItems"></param>
        /// <param name="datePlaced"></param>
        /// <returns>Error message based on the output</returns>
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
                Error += "The Description should not be blank\n";
            }

            if (description.Length >= 50)
            {
                // Concatenate the error message string
                Error += "The Employee Name you have entered is too long, Must be less Than 50 Char\n";
            }

            // JobDescriptionPermissions
            if (totalItems.Length == 0)
            {
                // Concatenate the error message string
                Error += "The order cannot be empty\n";
            }

            // DatePlaced
            try
            {

                //create a temp variable
                TempDate = Convert.ToDateTime(datePlaced);
                if (TempDate < DateTime.Now.Date)
                {
                    // Concatenate the error message string
                    Error += "Invalid past date\n";
                }

                if (TempDate > DateTime.Now.Date)
                {
                    // Concatenate the error message string
                    Error += "Invalid future date\n";
                }
            }
            catch
            {
                // Concatenate the error message string
                Error += "The Date Was Not A Valid Date\n";
            }

            // TotalCost
            try
            {

                // Create a temporary variable
                TempCost = Convert.ToDecimal(totalCost);
                if (TempCost < 0)
                {
                    // Concatenate the error message string
                    Error += "The order's total cost cannot be below 0\n";
                }

                if (TempCost > 50000)
                {
                    // Concatenate the error message string 
                    Error += "The order's total cost cannot exceed 50000\n";
                }
            }
            catch
            {
                // Concatenate the error message string
                Error += "The data entered was not decimal\n";
            }
            // return the error message string
            return Error;
        }

    }
}