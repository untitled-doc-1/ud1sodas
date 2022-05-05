using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ClassLibrary;

namespace tstCustomer
{
    [TestClass]
    public class tstCustomer
    {
        [TestMethod]
        [DataRow("FullName", "Test Testsson")]
        [DataRow("Email", "test.testsson@test.se")]
        [DataRow("PasswordHash", "AAABBBCCC111222333")]
        [DataRow("AddressLine1", "Test me!")]
        [DataRow("PhoneNumber", "01110001233")]
        [DataRow("Disabled", false)]
        public void Customer_InstantiateWithSingleProperties_InstantiatesProperly(string property, object value)
        {
            // arrange
            var customer = new clsCustomer();
            var customerProperty = customer.GetType().GetProperty(property);
            // act
            customerProperty.SetValue(customer, value);
            // assert
            Assert.AreEqual(value, customerProperty.GetValue(customer));
        }

        [TestMethod]
        [DataRow("FullName", "This is a ridiculous way of testing.")]
        [DataRow("Email", "i.really.do.not.agree.with.this@test.com")]
        [DataRow("PasswordHash", "AAABBBCCC111222333")]
        [DataRow("AddressLine1", "Test Me!")]
        [DataRow("PhoneNumber", "01110001233")]
        [DataRow("Disabled", false)]
        public void Find_IdThree_FindsProperties(string property, object value)
        {
            // arrange
            var customer = new clsCustomer();
            var customerProperty = customer.GetType().GetProperty(property);
            // act
            var found = customer.Find(3);
            // assert
            Assert.IsTrue(found);
            Assert.AreEqual(value, customerProperty.GetValue(customer));
        }

        public void Customer_InstatiateWithoutProperties_InstantiatesProperly()
        {
            // arrange
            // act
            var customer = new clsCustomer();
            // assert
            Assert.IsNotNull(customer);
        }

        [TestMethod]
        public void Customer_InstatiateWithSingleDateTimeProperty_InstatiatesPropery()
        {
            // arrange
            var customer = new clsCustomer();
            var timeNow = DateTime.Now;
            // act
            customer.SignedUpDate = timeNow;
            // assert
            Assert.AreEqual(timeNow, customer.SignedUpDate);
        }

        [TestMethod]

        public void Find_IdThree_ReturnsTrue()
        {
            // arrange
            var customer = new clsCustomer();
            // act
            var result = customer.Find(3);
            // assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void Validate_CorrectData_ProducesEmptyString()
        {
            // arrange
            var customerName = "Testy McTestface";
            var customerEmail = "testy@mctestface.com";
            var passwordHash = "b1ffb6b5d22cd9f210fbc8b7fdaf0e19";
            var signUpDate = DateTime.UtcNow;
            var addressLine1 = "1 McTestFace Road";
            var disabled = false;
            var phoneNumber = "01161230987";

            var customer = new clsCustomer();
            // act
            var errorMessage = customer.Validate(customerName, customerEmail, passwordHash, addressLine1, phoneNumber, disabled, signUpDate);

            // assert
            Assert.AreEqual(String.Empty, errorMessage);
        }

        [TestMethod]
        public void Validate_IncorrectPhoneNumber_ProducesErrorString()
        {
            // arrange
            var customerName = "Testy McTestface";
            var customerEmail = "testy@mctestface.com";
            var passwordHash = "b1ffb6b5d22cd9f210fbc8b7fdaf0e19";
            var signUpDate = DateTime.UtcNow;
            var addressLine1 = "1 McTestFace Road";
            var disabled = false;
            var phoneNumber = "0116 123 0987";

            var customer = new clsCustomer();
            // act
            var errorMessage = customer.Validate(customerName, customerEmail, passwordHash, addressLine1, phoneNumber, disabled, signUpDate);

            // assert
            var errorString = $"Error: {System.Environment.NewLine}" + $"Phone numbers must be 11 characters long, start with a zero and cannot contain any spaces.{System.Environment.NewLine}";
            Assert.AreEqual(errorString, errorMessage);
        }

        [TestMethod]
        public void Validate_IncorrectPhoneNumberAndEmail_ProducesErrorString()
        {
            // arrange
            var customerName = "Testy McTestface";
            var customerEmail = "testy@mctestface";
            var passwordHash = "b1ffb6b5d22cd9f210fbc8b7fdaf0e19";
            var signUpDate = DateTime.UtcNow;
            var addressLine1 = "1 McTestFace Road";
            var disabled = false;
            var phoneNumber = "0116 123 0987";

            var customer = new clsCustomer();
            // act
            var errorMessage = customer.Validate(customerName, customerEmail, passwordHash, addressLine1, phoneNumber, disabled, signUpDate);

            // assert
            var errorString = $"Error: {System.Environment.NewLine}" 
                + $"Phone numbers must be 11 characters long, start with a zero and cannot contain any spaces.{System.Environment.NewLine}"
                + $"Email is invalid.{System.Environment.NewLine}";
            Assert.AreEqual(errorString, errorMessage);
        }

        [TestMethod]
        public void Validate_EmptyStrings_ProducesErrorString()
        {
            // arrange
            var customerName = "";
            var customerEmail = "";
            var passwordHash = "";
            var signUpDate = DateTime.UtcNow;
            var addressLine1 = "";
            var disabled = false;
            var phoneNumber = "";

            var customer = new clsCustomer();
            // act
            var errorMessage = customer.Validate(customerName, customerEmail, passwordHash, addressLine1, phoneNumber, disabled, signUpDate);

            // assert
            var expectedErrorMessage = $"Error: {System.Environment.NewLine}" +
                $"Phone numbers must be 11 characters long, start with a zero and cannot contain any spaces.{System.Environment.NewLine}" +
                $"Email is invalid.{System.Environment.NewLine}" +
                $"Name is empty.{System.Environment.NewLine}" +
                $"Address is empty.{System.Environment.NewLine}" +
                $"Password hash is empty.{System.Environment.NewLine}";
            Assert.AreEqual(expectedErrorMessage, errorMessage);
        }
    }
}
