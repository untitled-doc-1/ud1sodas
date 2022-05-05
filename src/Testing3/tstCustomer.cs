using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ClassLibrary;

namespace Testing3
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
        public void Customer_Find_FindsProperties(string property, object value)
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

        public void Customer_Find_ReturnsTrue()
        {
            // arrange
            var customer = new clsCustomer();
            // act
            var result = customer.Find(3);
            // assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void Customer_ValidateWithCorrectData_ProducesEmptyString()
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
            Assert.AreEqual(String.Empty, errorMessage);
        }
    }
}
