using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class clsCustomerCollection
    {
        private List<clsCustomer> mCustomerList;
        private clsCustomer mThisCustomer;

        public List<clsCustomer> CustomerList
        {
            get
            {
                return mCustomerList;
            }
            set
            {
                mCustomerList = value;
            }
        }
        
        public int Count
        {
            get
            {
                return mCustomerList.Count;
            }
            set
            {
            }
        }

        public clsCustomer ThisCustomer
        {
            get
            {
                return mThisCustomer;
            }
            set
            {
                mThisCustomer = value;
            }
        }


        public clsCustomerCollection()
        {
            mCustomerList = new List<clsCustomer>();

            // never ever put data fetching logic in a constructor
            var db = new clsDataConnection();
            db.Execute("sproc_tblCustomer_SelectAll");
            var rows = db.Count;

            for (var i = 0; i < rows; i++)
            {
                var customer = new clsCustomer();
                customer.AddressLine1 = Convert.ToString(db.DataTable.Rows[i]["AddressLine1"]);
                customer.Email = Convert.ToString(db.DataTable.Rows[i]["Email"]);
                customer.PasswordHash = Convert.ToString(db.DataTable.Rows[i]["PasswordHash"]);
                customer.FullName = Convert.ToString(db.DataTable.Rows[i]["FullName"]);
                customer.PhoneNumber = Convert.ToString(db.DataTable.Rows[i]["PhoneNumber"]);
                customer.Disabled = Convert.ToBoolean(db.DataTable.Rows[i]["Disabled"]);
                mCustomerList.Add(customer);
            }
        }
    }
}