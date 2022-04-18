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

        /// <summary>
        /// Order ID
        /// </summary>
        private int mID;

        /// <summary>
        /// Order description
        /// </summary>
        private string mDescription;

        /// <summary>
        /// Total items in Order
        /// </summary>
        private int mTotalItems;

        /// <summary>
        /// Total cost of the Order
        /// </summary>
        private decimal mTotalCost;

        /// <summary>
        /// Fulfilment status of the order - has it been processed?
        /// </summary>
        private bool mFulfillment_status;

        /// <summary>
        /// Date of when the order was placed
        /// </summary>
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
            // Initializes an instance of the database connection class
            clsDataConnection DB = new clsDataConnection();
            // Adding SQL parameter for OrderID to be searched
            DB.AddParameter("@OrderID", OrderID);
            // Execute the stored procedure
            DB.Execute("sproc_tblOrder_FilterByOrderID");
            // If a matching record is found (there should only be one exact match)
            if (DB.Count == 1)
            {
                mID = Convert.ToInt32(DB.DataTable.Rows[0]["OrderID"]);
                mDescription = Convert.ToString(DB.DataTable.Rows[0]["Description"]);
                mTotalItems = Convert.ToInt32(DB.DataTable.Rows[0]["TotalItems"]);
                mTotalCost = Convert.ToDecimal(DB.DataTable.Rows[0]["TotalCost"]);
                mDatePlaced = Convert.ToDateTime(DB.DataTable.Rows[0]["DatePlaced"]);
                mFulfillment_status = Convert.ToBoolean(DB.DataTable.Rows[0]["Fulfilment"]);
                // Return true if successful
                return true;
            }
            // if a matching record is not found
            else
            {
                // Return false indicating an issue
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
        public static string Validate(string description, string totalCost, string totalItems, string datePlaced)
        {
            // create a string variable to store the error message string
            string Error = "";
            // temporary variable to store date values
            DateTime TempDate;
            // temporary variable to store the salary
            Decimal TempCost;

            // Description
            // if the description field is blank
            if (description == "")
            {
                // Concatenate the error message string
                Error += "The Description should not be blank\n";
            }

            if (description.Length >= 50)
            {
                // Concatenate the error message string
                Error += "The description you have entered is too long, Must be less Than 50 characters\n";
            }

            try
            {
                // Total Items
                if (Int32.Parse(totalItems) <= 0)
                {
                    // Concatenate the error message string
                    Error += "The order must contain at least 1 item\n";
                }
            }
            catch
            {
                Error += "Error while parsing the order quantity. Please enter a valid number\n";
            }
            

            // DatePlaced
            try
            {

                //create a temporary variable to hold the order date
                TempDate = Convert.ToDateTime(datePlaced).Date;
                if (TempDate.Date < DateTime.Now.Date)
                {
                    // Concatenate the error message string
                    Error += "Invalid past date\n";
                }

                if (TempDate.Date > DateTime.Now.Date)
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
                if (TempCost <= 0)
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