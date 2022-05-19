using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Testing4
{

    [TestClass]
    public class tstStock
    {

        //good test data
        string StockDescription = "TestDescription";
        string StockSupplier = "TestStockSupplier";
        string DateArrived = DateTime.Now.Date.ToString();
        string SupplierAddress = "21";






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

        public void StockDateArrived()
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

        public void AStockDescription()
        {
            //creation of class instance
            clsStock AStock = new clsStock();


            //data test
            String TestData = "";

            AStock.StockDescription = TestData;

            Assert.AreEqual(AStock.StockDescription, TestData);



        }

        [TestMethod]

        public void AStockSupplier()
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

            Int32 StockID = 1;

            Found = AStock.Find(StockID);

            Assert.IsTrue(Found);

        }

        [TestMethod]

        public void TestStockNoFound()
        {
            clsStock AStock = new clsStock();

            Boolean Found = false;

            Boolean OK = true;

            Int32 StockID = 1;

            Found = AStock.Find(StockID);

            if (AStock.StockID != 1)
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

            Int32 StockID = 1;

            Found = AStock.Find(StockID);

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

            Int32 StockID = 1;

            Found = AStock.Find(StockID);

            if (AStock.StockDescription != "TestDescription")
            {
                OK = false;
            }

            Assert.IsTrue(OK);

        }


        [TestMethod]

        public void TestStockAvailabilityFound()
        {

            clsStock AStock = new clsStock();

            Boolean Found = false;

            Boolean OK = true;

            Int32 StockID = 1;

            Found = AStock.Find(StockID);

            if (AStock.StockAvailability != true)
            {
                OK = false;
            }

            Assert.IsTrue(OK);

        }



        [TestMethod]

        public void TestStockSupplierFound()
        {

            clsStock AStock = new clsStock();

            Boolean Found = false;

            Boolean OK = true;

            Int32 StockID = 1;

            Found = AStock.Find(StockID);

            if (AStock.StockSupplier != "TestStockSupplier")
            {
                OK = false;
            }

            Assert.IsTrue(OK);

        }

        [TestMethod]

        public void ValidMethodOK()
        {

            clsStock AStock = new clsStock();

            String Error = "";

            Error = AStock.Valid(SupplierAddress, StockDescription, StockSupplier, DateArrived);

            Assert.AreEqual(Error, "");


        }











   



        }





    }



       

       







    
