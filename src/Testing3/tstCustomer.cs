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
        [DataRow("Address", "Test me!")]
        [DataRow("PhoneNumber", 01110001233)]
        [DataRow("Disabled", false)]
        public void Customer_InstantiateWithSingleProperties_InstantiatesProperly(string property, object value)
        {
            // arrange
            var customer = new Customer();
            var customerProperty = customer.GetType().GetProperty(property);
            // act
            customerProperty.SetValue(customer, value);
            // assert
            Assert.AreEqual(value, customerProperty.GetValue(customer));

        }

        public void Customer_InstatiateWithoutProperties_InstantiatesProperly()
        {
            // arrange
            // act
            var customer = new Customer();
            // assert
            Assert.IsNotNull(customer);
        }

        [TestMethod]
        public void Customer_InstatiateWithSingleDateTimeProperty_InstatiatesPropery()
        {
            // arrange
            var customer = new Customer();
            var timeNow = DateTime.Now;
            // act
            customer.SignedUpDate = timeNow;
            // assert
            Assert.AreEqual(timeNow, customer.SignedUpDate);
        }
    }
}
