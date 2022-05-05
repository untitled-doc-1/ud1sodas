using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace tstCustomer
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
        public void Add_AddNewCustomer_ReturnsNewPrimaryKey()
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
            customerCollection.ThisCustomer = customer;

            // act
            //var pk = customerCollection.Add();
            //customer.Id = pk;

            // assert
            //Assert.AreEqual(customer, customerCollection.ThisCustomer);
        }

        [TestMethod]
        public void Update_UpdateNewCustomer_UpdatePropagates()
        {
            // arrange
            var customer = new clsCustomer();
            customer.FullName = "Testy McTestface - Update test!";
            customer.Email = "testy@mctestface.com";
            customer.PasswordHash = "b1ffb6b5d22cd9f210fbc8b7fdaf0e19";
            customer.SignedUpDate = DateTime.UtcNow;
            customer.AddressLine1 = "2 McTestFace Road";
            customer.Disabled = false;
            customer.PhoneNumber = "01161230987";
            var customerCollection = new clsCustomerCollection();
            customerCollection.ThisCustomer = customer;

            var pk = customerCollection.Add();
            customer.Id = pk;

            customer.FullName = "Testy McTestface - Update success!";
            customer.Email = "testy-updated@mctestface.com";
            customer.PasswordHash = "updated-b1ffb6b5d22cd9f210fbc8b7fdaf0e19";
            customer.SignedUpDate = DateTime.UtcNow;
            customer.AddressLine1 = "2 Updated McTestFace Road";
            customer.Disabled = false;
            customer.PhoneNumber = "01161230988";
            customerCollection.ThisCustomer = customer;

            // act
            customerCollection.Update();

            // assert
            customerCollection.ThisCustomer.Find(pk);
            Assert.AreEqual(customer, customerCollection.ThisCustomer);
        }

        [TestMethod]
        public void Delete_CreateThenDeleteCustomer_DeletesCustomer()
        {
            // arrange
            var customer = new clsCustomer();
            customer.FullName = "Testy McTestface - Delete test!";
            customer.Email = "testy@mctestface.com";
            customer.PasswordHash = "b1ffb6b5d22cd9f210fbc8b7fdaf0e19";
            customer.SignedUpDate = DateTime.UtcNow;
            customer.AddressLine1 = "2 McTestFace Road";
            customer.Disabled = false;
            customer.PhoneNumber = "01161230987";
            var customerCollection = new clsCustomerCollection();
            customerCollection.ThisCustomer = customer;

            var pk = customerCollection.Add();
            customer.Id = pk;

            // act
            customerCollection.Delete();

            // assert
            var found = customerCollection.ThisCustomer.Find(pk);
            Assert.IsFalse(found);
        }

        //[TestMethod]
        //public void CustomerCollection_InitializeWithContentFromDatabase_ReturnsThreeCustomers()
        //{
        //    // arrange
        //    var customerCollection = new clsCustomerCollection();
        //    // act
        //    var count = customerCollection.Count;
        //    // assert
        //    Assert.AreEqual(4, count);
        //}
    }
}
