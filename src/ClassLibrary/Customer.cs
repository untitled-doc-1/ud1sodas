using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Customer
    {
        private string mFullName;
        private string mEmail;
        private string mPasswordHash;
        private DateTime mSignedUpDate;
        private string mAddress;
        private int mPhoneNumber;
        private bool mDisabled;

        public int Id { get; set; }
        public string FullName {
            get
            {
                return mFullName;
            }
            set
            {
                mFullName = value;
            }
        }
        public string Email
        {
            get
            {
                return mEmail;
            }
            set
            {
                mEmail = value;
            }
        }
        public string PasswordHash
        {
            get
            {
                return mPasswordHash;
            }
            set
            {
                mPasswordHash = value;
            }
        }
        public DateTime SignedUpDate
        {
            get
            {
                return mSignedUpDate;
            }
            set
            {
                mSignedUpDate = value;
            }
        }
        public string Address
        {
            get
            {
                return mAddress;
            }
            set
            {
                mAddress = value;
            }
        }
        public int PhoneNumber
        {
            get
            {
                return mPhoneNumber;
            }
            set
            {
                mPhoneNumber = value;
            }
        }
        public bool Disabled
        {
            get
            {
                return mDisabled;
            }
            set
            {
                mDisabled = value;
            }
        }

        public bool Find(int customerId)
        {
            mFullName = "This is a ridiculous way of testing.";
            mEmail = "i.really.do.not.agree.with.this@test.com";
            mAddress = "Test me!";
            mPhoneNumber = 01110001233;
            mPasswordHash = "AAABBBCCC111222333";
            mDisabled = false;
            
            return true;
        }

        public bool FindViaDatabase(int customerId)
        {
            var db = new clsDataConnection();
            db.AddParameter("@CustomerId", customerId);
            db.Execute("sproc_Customer_FilterByCustomerId");
            
            if (db.Count > 0)
            {
                mAddress = Convert.ToString(db.DataTable.Rows[0]["Address"]);
                mEmail = Convert.ToString(db.DataTable.Rows[0]["Email"]);
                mPasswordHash = Convert.ToString(db.DataTable.Rows[0]["PasswordHash"]);
                mFullName = Convert.ToString(db.DataTable.Rows[0]["FullName"]);
                mPhoneNumber = Convert.ToInt32(db.DataTable.Rows[0]["PhoneNumber"]);
                mDisabled = Convert.ToBoolean(db.DataTable.Rows[0]["Disabled"]);
            }
            return true;
        }
    }

}
