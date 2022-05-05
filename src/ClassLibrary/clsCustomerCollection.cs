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
            mThisCustomer = new clsCustomer();

            // never ever put data fetching logic in a constructor
            var db = new clsDataConnection();
            db.Execute("sproc_tblCustomer_SelectAll");
            var rows = db.Count;

            for (var i = 0; i < rows; i++)
            {
                var customer = new clsCustomer();
                customer.Id = Convert.ToInt32(db.DataTable.Rows[i]["Id"]);
                customer.AddressLine1 = Convert.ToString(db.DataTable.Rows[i]["AddressLine1"]);
                customer.Email = Convert.ToString(db.DataTable.Rows[i]["Email"]);
                customer.PasswordHash = Convert.ToString(db.DataTable.Rows[i]["PasswordHash"]);
                customer.FullName = Convert.ToString(db.DataTable.Rows[i]["FullName"]);
                customer.PhoneNumber = Convert.ToString(db.DataTable.Rows[i]["PhoneNumber"]);
                customer.Disabled = Convert.ToBoolean(db.DataTable.Rows[i]["Disabled"]);
                mCustomerList.Add(customer);
            }
        }

        public int Add()
        {
            if (ThisCustomer.ValidateCurrentlySetData() != String.Empty)
            {
                throw new ApplicationException("The customer was not validated prior to adding.");
            }

            var db = new clsDataConnection();
            db.AddParameter("@FullName", mThisCustomer.FullName);
            db.AddParameter("@Email", mThisCustomer.Email);
            db.AddParameter("@PasswordHash", mThisCustomer.PasswordHash);
            db.AddParameter("@SignedUpDate", mThisCustomer.SignedUpDate);
            db.AddParameter("@PhoneNumber", mThisCustomer.PhoneNumber);
            db.AddParameter("@AddressLine1", mThisCustomer.AddressLine1);
            db.AddParameter("@Disabled", mThisCustomer.Disabled);
            return db.Execute("sproc_tblCustomer_Add");
        }

        public void Update()
        {
            if (ThisCustomer.ValidateCurrentlySetData() != String.Empty)
            {
                throw new ApplicationException("The customer was not validated prior to updating.");
            }

            var db = new clsDataConnection();
            db.AddParameter("@Id", mThisCustomer.Id);
            db.AddParameter("@FullName", mThisCustomer.FullName);
            db.AddParameter("@Email", mThisCustomer.Email);
            db.AddParameter("@PasswordHash", mThisCustomer.PasswordHash);
            db.AddParameter("@SignedUpDate", mThisCustomer.SignedUpDate);
            db.AddParameter("@PhoneNumber", mThisCustomer.PhoneNumber);
            db.AddParameter("@AddressLine1", mThisCustomer.AddressLine1);
            db.AddParameter("@Disabled", mThisCustomer.Disabled);
            db.Execute("sproc_tblCustomer_Update");
        }

        public bool Delete()
        {
            var db = new clsDataConnection();
            db.AddParameter("@Id", mThisCustomer.Id);
            db.Execute("sproc_tblCustomer_Delete");
            return !ThisCustomer.Find(mThisCustomer.Id);
        }
    }
}