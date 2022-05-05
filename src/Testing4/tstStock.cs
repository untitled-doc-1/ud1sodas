using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Testing4
{
    [TestClass]
    public class tstStock
    {
        [TestMethod]
        public void InstanceOK()
        {
            //creation of class instance
            var AStock = new clsStock();

            //existance testing
            Assert.IsNotNull(AStock);


        }

        [TestMethod]

        public void ActivePropertyOK()
        {
            //creation of class instance
            var AStock = new clsStock();

            //data test
            var TestData = true;

            //data assignment
            AStock.Active = TestData;

            //test if both values are equal
            Assert.AreEqual(AStock.Active, TestData);



        }

        [TestMethod]

        public void DateArrived()
        {
            //creation of class instance
            var AStock = new clsStock();

            //data test
            var TestData = DateTime.Now.Date;

            //data assignment
            AStock.DateAdded = TestData;

            //test if both values are equal
            Assert.AreEqual(AStock.DateAdded, TestData);


        }

        [TestMethod]

        public void StockAvailability()
        {
            //creation of class instance
            var AStock = new clsStock();

            //data test
            var TestData = true;

            AStock.StockAvailability = TestData;

            Assert.AreEqual(AStock.StockAvailability, TestData);


        }


        [TestMethod]

        public void StockDescription()
        {
            //creation of class instance
            var AStock = new clsStock();

            //data test
            var TestData = "";

            AStock.StockDescription = TestData;

            Assert.AreEqual(AStock.StockDescription, TestData);



        }

        [TestMethod]

        public void StockSupplier()
        {
            //creation of class instance
            var AStock = new clsStock();

            var TestData = "";

            AStock.StockSupplier = TestData;

            Assert.AreEqual(AStock.StockSupplier, TestData);


        }

        [TestMethod]

        public void StockID()
        {
            //creatiion of class instance
            var AStock = new clsStock();

            var TestData = 1;

            AStock.StockID = TestData;

            Assert.AreEqual(AStock.StockID, TestData);


        }
    }
}
