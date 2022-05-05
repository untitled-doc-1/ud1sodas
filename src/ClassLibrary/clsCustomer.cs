using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        public string FullName
        {
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
        // https://docs.microsoft.com/en-us/dotnet/standard/base-types/how-to-verify-that-strings-are-in-valid-email-format
        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        public string ValidateCurrentlySetData()
        {
            return Validate(mFullName, mEmail, mPasswordHash, mAddressLine1, mPhoneNumber, mDisabled, mSignedUpDate);
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
                {"validPhoneNumber", "Phone numbers must be 11 characters long, start with a zero and cannot contain any spaces." },
                {"validEmail", "Email is invalid." },
                {"validName", "Name is empty." },
                {"validAddress", "Address is empty." },
                {"validPasswordHash", "Password hash is empty." },
                {"validSignedUpDate", "The sign up date cannot be MinValue." },
            };

            // UK phone numbers are 11 digits long
            // e.g. 0116 123 4567
            if (phoneNumber.Contains(" ") || phoneNumber.Length != 11 || !phoneNumber.StartsWith("0"))
            {
                validationParameters["validPhoneNumber"] = false;
            }

            // borrow email validation from built-in attribute
            validationParameters["validEmail"] = IsValidEmail(customerEmail);

            // validate name is not empty
            validationParameters["validName"] = !string.IsNullOrWhiteSpace(customerName);

            // validate address is not empty
            validationParameters["validAddress"] = !string.IsNullOrWhiteSpace(addressLine1);

            // validate password hash is not empty
            validationParameters["validPasswordHash"] = !string.IsNullOrEmpty(passwordHash);

            // validate sign up date is not datetime minvalue
            // there is no need for min/max tests as realistically this would be set by the server and NOT the client.
            validationParameters["validSignedUpDate"] = signedUpDate != DateTime.MinValue;

            var errorStringBuilder = new StringBuilder();
            errorStringBuilder.AppendLine("Error: ");
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
            db.Execute("sproc_tblCustomer_FilterByCustomerId");

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
