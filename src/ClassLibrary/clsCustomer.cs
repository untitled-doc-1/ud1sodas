using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class clsCustomer
    {
        private string mFullName;
        private string mEmail;
        private string mPasswordHash;
        private DateTime mSignedUpDate;
        private string mAddressLine1;
        private string mPhoneNumber;
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
        public string AddressLine1
        {
            get
            {
                return mAddressLine1;
            }
            set
            {
                mAddressLine1 = value;
            }
        }
        public string PhoneNumber
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

        public bool MockedFind(int customerId)
        {
            mFullName = "This is a ridiculous way of testing.";
            mEmail = "i.really.do.not.agree.with.this@test.com";
            mAddressLine1 = "Test me!";
            mPhoneNumber = "01110001233";
            mPasswordHash = "AAABBBCCC111222333";
            mDisabled = false;
            
            return true;
        }

        public string Validate(string customerName, string customerEmail, string passwordHash, string addressLine1, string phoneNumber, bool disabled, DateTime signedUpDate)
        {
            // validation parameters
            var validationParameters = new Dictionary<string, bool>()
            {
                {"validPhoneNumber", true },
                {"validEmail", true },
                {"validName", true },
                {"validAddress", true },
                {"validPasswordHash", true },
                {"validSignedUpDate", true },
            };

            var errorMessages = new Dictionary<string, string>()
            {
                {"validPhoneNumber", "Phone numbers must be 11 characters long and start with a zero." },
                {"validEmail", "Email is invalid." },
                {"validName", "Name is empty." },
                {"validAddress", "Address is empty." },
                {"validPasswordHash", "Password hash is empty." },
                {"validSignedUpDate", "The sign up date cannot be MinValue." },
            };

            // UK phone numbers are 11 digits long
            // e.g. 0116 123 4567
            if (phoneNumber.Length != 11 && !phoneNumber.StartsWith("0"))
            {
                validationParameters["validPhoneNumber"] = false;
            }

            // borrow email validation from built-in attribute
            validationParameters["validEmail"] = new EmailAddressAttribute().IsValid(customerEmail) && !string.IsNullOrEmpty(customerEmail);

            // validate name is not empty
            validationParameters["validName"] = !string.IsNullOrWhiteSpace(customerName);

            // validate address is not empty
            validationParameters["validAddress"] = !string.IsNullOrWhiteSpace(addressLine1);

            // validate password hash is not empty
            validationParameters["validPasswordHash"] = !string.IsNullOrEmpty(passwordHash);

            // validate sign up date is not datetime minvalue
            validationParameters["validSignedUpDate"] = signedUpDate != DateTime.MinValue;

            var errorStringBuilder = new StringBuilder();
            errorStringBuilder.Append("Error:");
            var errorsFound = false;
            foreach (var parameter in validationParameters.Keys)
            {
                if (!validationParameters[parameter])
                {
                    errorsFound = true;
                    errorStringBuilder.AppendLine(errorMessages[parameter]);
                }
            }


            if (errorsFound)
            {
                return errorStringBuilder.ToString();
            }
            return "";
        }

        public bool Find(int customerId)
        {
            var db = new clsDataConnection();
            db.AddParameter("@CustomerId", customerId);
            db.Execute("sproc_Customer_FilterByCustomerId");
            
            if (db.Count == 1)
            {
                mAddressLine1 = Convert.ToString(db.DataTable.Rows[0]["AddressLine1"]);
                mEmail = Convert.ToString(db.DataTable.Rows[0]["Email"]);
                mPasswordHash = Convert.ToString(db.DataTable.Rows[0]["PasswordHash"]);
                mFullName = Convert.ToString(db.DataTable.Rows[0]["FullName"]);
                mPhoneNumber = Convert.ToString(db.DataTable.Rows[0]["PhoneNumber"]);
                mDisabled = Convert.ToBoolean(db.DataTable.Rows[0]["Disabled"]);
                return true;
            }
            return false;
        }
    }

}
