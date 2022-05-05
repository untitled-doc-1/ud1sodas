using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Testing3
{
    [TestClass]
    public class tstCustomerCollection
    {
        [TestMethod]
        public void CustomerCollecton_CreateInstance_IsNotNull()
        {
            // arrange

            // act
            var customerCollection = new clsCustomerCollection();
            // assert
            Assert.IsNotNull(customerCollection);
        }


        [TestMethod]
        public void CustomerCollecton_CreateCustomerAndSetCustomerList_SetsCustomerList()
        {
            // arrange
            var customer = new clsCustomer();
            var customerList = new List<clsCustomer>();

            customer.FullName = "Testy McTestface";
            customer.Email = "testy@mctestface.com";
            customer.PasswordHash = "b1ffb6b5d22cd9f210fbc8b7fdaf0e19";
            customer.SignedUpDate = DateTime.UtcNow;
            customer.AddressLine1 = "1 McTestFace Road";
            customer.Disabled = false;
            customer.PhoneNumber = "01161230987";

            var customerCollection = new clsCustomerCollection();

            customerList.Add(customer);

            // act
            customerCollection.CustomerList = customerList;

            // assert
            // useless assertion, this only checks the object reference and not its values
            Assert.AreEqual(customerList, customerCollection.CustomerList);
        }

        [TestMethod]
        public void CustomerCollecton_CreateCustomerSingleCustomerAndSetCustomerList_CountIsOne()
        {
            // arrange
            var customer = new clsCustomer();
            var customerList = new List<clsCustomer>();

            customer.FullName = "Testy McTestface";
            customer.Email = "testy@mctestface.com";
            customer.PasswordHash = "b1ffb6b5d22cd9f210fbc8b7fdaf0e19";
            customer.SignedUpDate = DateTime.UtcNow;
            customer.AddressLine1 = "1 McTestFace Road";
            customer.Disabled = false;
            customer.PhoneNumber = "01161230987";

            var customerCollection = new clsCustomerCollection();

            customerList.Add(customer);

            // act
            customerCollection.CustomerList = customerList;

            // assert
            Assert.AreEqual(customerList.Count, customerCollection.Count);
        }

        [TestMethod]
        public void CustomerCollecton_CreateCustomerAndSetThisCustomer_OK()
        {
            // arrange
            var customer = new clsCustomer();
            customer.FullName = "Testy McTestface";
            customer.Email = "testy@mctestface.com";
            customer.PasswordHash = "b1ffb6b5d22cd9f210fbc8b7fdaf0e19";
            customer.SignedUpDate = DateTime.UtcNow;
            customer.AddressLine1 = "1 McTestFace Road";
            customer.Disabled = false;
            customer.PhoneNumber = "01161230987";
            var customerCollection = new clsCustomerCollection();

            // act
            customerCollection.ThisCustomer = customer;

            // assert
            Assert.AreEqual(customer, customerCollection.ThisCustomer);
        }

        [TestMethod]
        public void CustomerCollecton_AddItemToCollection_OK()
        {
            // arrange
            var customer = new clsCustomer();
            customer.FullName = "Testy McTestface";
            customer.Email = "testy@mctestface.com";
            customer.PasswordHash = "b1ffb6b5d22cd9f210fbc8b7fdaf0e19";
            customer.SignedUpDate = DateTime.UtcNow;
            customer.AddressLine1 = "1 McTestFace Road";
            customer.Disabled = false;
            customer.PhoneNumber = "01161230987";
            var customerCollection = new clsCustomerCollection();

            // act
            // customerCollection.Add(customer);

            // assert
            Assert.IsNotNull(customerCollection);
        }

        [TestMethod]
        public void CustomerCollection_InitializeWithContentFromDatabase_ReturnsThreeCustomers()
        {
            // arrange
            var customerCollection = new clsCustomerCollection();
            // act
            var count = customerCollection.Count;
            // assert
            Assert.AreEqual(3, count);
        }
    }
}
