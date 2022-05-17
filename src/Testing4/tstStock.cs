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
            clsStock AStock = new clsStock();

            //existance testing
            Assert.IsNotNull(AStock);


        }

        [TestMethod]

        public void ActivePropertyOK()
        {
            //creation of class instance
            clsStock AStock = new clsStock();


            //data test
            Boolean TestData = true;

            //data assignment
            AStock.Active = TestData;

            //test if both values are equal
            Assert.AreEqual(AStock.Active, TestData);



        }

        [TestMethod]

        public void DateArrived()
        {
            //creation of class instance
            clsStock AStock = new clsStock();

            //data test
            DateTime TestData = DateTime.Now.Date;

            //data assignment
            AStock.DateAdded = TestData;

            //test if both values are equal
            Assert.AreEqual(AStock.DateAdded, TestData);


        }

        [TestMethod]

        public void StockAvailability()
        {
            //creation of class instance
            clsStock AStock = new clsStock();


            //data test
            Boolean TestData = true;

            AStock.StockAvailability = TestData;

            Assert.AreEqual(AStock.StockAvailability, TestData);


        }


        [TestMethod]

        public void StockDescription()
        {
            //creation of class instance
            clsStock AStock = new clsStock();


            //data test
            String TestData = "";

            AStock.StockDescription = TestData;

            Assert.AreEqual(AStock.StockDescription, TestData);



        }

        [TestMethod]

        public void StockSupplier()
        {
            //creation of class instance
            clsStock AStock = new clsStock();


            String TestData = "";

            AStock.StockSupplier = TestData;

            Assert.AreEqual(AStock.StockSupplier, TestData);


        }

        [TestMethod]

        public void StockID()
        {
            //creatiion of class instance
            clsStock AStock = new clsStock();


            Int32 TestData = 1;

            AStock.StockID = TestData;

            Assert.AreEqual(AStock.StockID, TestData);


        }

        [TestMethod]

        public void FindMethodOK()
        {

            clsStock AStock = new clsStock();

            Boolean Found = false;

            Int32 SupplierAddress = 21;

            Found = AStock.Find(SupplierAddress);

            Assert.IsTrue(Found);

        }

        [TestMethod]

        public void TestAddressNoFound()
        {
            clsStock AStock = new clsStock();

            Boolean Found = false;

            Boolean OK = true;

            Int32 SupplierAddress = 21;

            Found = AStock.Find(SupplierAddress);

            if (AStock.StockID != 21)
            {
                OK = false;
            }

            Assert.IsTrue(OK);


        }

        [TestMethod]

        public void TestDateArrivedFound()
        {
            clsStock AStock = new clsStock();

            Boolean Found = false;

            Boolean OK = true;

            Int32 DateArrived = 21;

            Found = AStock.Find(DateArrived);

            if (AStock.DateArrived != Convert.ToDateTime("16/09/2015"))
            {
                OK = false;
            }

            Assert.IsTrue(OK);
        }


        [TestMethod]

        public void TestDescriptionFound()
        {

            clsStock AStock = new clsStock();

            Boolean Found = false;

            Boolean OK = true;

            Int32 StockDescription = 21;

            Found = AStock.Find(StockDescription);

            if (AStock.StockDescription != "Test Description")
            {
                OK = false;
            }

        }


        [TestMethod]

        public void TestStockAvailabilityFound()
        {

            clsStock AStock = new clsStock();

            Boolean Found = false;

            Boolean OK = true;

            Int32 StockAvailability = 21;

            Found = AStock.Find(StockAvailability);

            if (AStock.StockAvailability != true)
            {
                OK = false;
            }
        }

        public void TestStockSupplierFound()
        {

            clsStock AStock = new clsStock();

            Boolean Found = false;

            Boolean OK = true;

            Int32 StockSupplier = 21;

            Found = AStock.Find(StockSupplier);

            if (AStock.StockAvailability)





        }







        }





    }



       

       







    }
}
