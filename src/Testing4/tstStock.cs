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

            if (AStock.DateArrived != Convert.ToDateTime("20/05/2022"))
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

        [TestMethod]

        public void SupplierAddressMinLessOne()
        {

            clsStock AStock = new clsStock();

            string Error = "";

            string SupplierAddress = "";

            Error = AStock.Valid(SupplierAddress, StockDescription, StockSupplier, DateArrived);

            Assert.AreNotEqual(Error, "");


        }

        [TestMethod]

        public void SupplierAddressMinPlusOne()
        {
            clsStock AStock = new clsStock();

            String Error = "";

            string SupplierAddress = "aa";

            Error = AStock.Valid(SupplierAddress, StockDescription, StockSupplier, DateArrived);

            Assert.AreEqual(Error, "");


        }

        [TestMethod]

        public void SupplierAddressMaxLessOne()
        {

            clsStock AStock = new clsStock();

            String Error = "";

            string SupplierAddress = "";

            SupplierAddress = SupplierAddress.PadRight(49, 'a');

            Error = AStock.Valid(SupplierAddress, StockDescription, StockSupplier, DateArrived);

            Assert.AreEqual(Error, "");

        }

        [TestMethod]

        public void SupplierAddressMax()
        {
            clsStock AStock = new clsStock();

            String Error = "";

            String SupplierAddress = "";

            SupplierAddress = SupplierAddress.PadRight(50, 'a');

            Error = AStock.Valid(SupplierAddress, StockDescription, StockSupplier, DateArrived);

            Assert.AreEqual(Error, "");

        }

        [TestMethod]

        public void SupplierAddressMid()

        {

            clsStock AStock = new clsStock();

            String Error = "";

            String SupplierAddress = "";

            SupplierAddress = SupplierAddress.PadRight(25, 'a');

            Error = AStock.Valid(SupplierAddress, StockDescription, StockSupplier, DateArrived);

            Assert.AreEqual(Error, "");


        }

        [TestMethod]

        public void SupplierAddressMaxPlusOne()

        {

            clsStock AStock = new clsStock();

            String Error = "";

            string SupplierAddress = "";

            SupplierAddress = SupplierAddress.PadRight(51, 'a');

            Error = AStock.Valid(SupplierAddress, StockDescription, StockSupplier, DateArrived);

            Assert.AreNotEqual(Error, "");


        }

        [TestMethod]

        public void SupplierAddressExtremeMax()
        {

            clsStock AStock = new clsStock();

            string Error = "";

            string SupplierAddress = "";

            SupplierAddress = SupplierAddress.PadRight(500, 'a');

            Error = AStock.Valid(SupplierAddress, StockDescription, StockSupplier, DateArrived);

            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]

        public void DateArrivedExtremeMin()
        {
            clsStock AStock = new clsStock();

            String Error = "";

            DateTime TestDate;

            TestDate = DateTime.Now.Date;

            TestDate = TestDate.AddYears(-100);

            string DateArrived = TestDate.ToString();

            Error = AStock.Valid(SupplierAddress, StockDescription, StockSupplier, DateArrived);

            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]

        public void DateArrivedMinLessOne()
        {
            clsStock AStock = new clsStock();

            String Error = "";

            DateTime TestDate;

            TestDate = DateTime.Now.Date;

            TestDate = TestDate.AddDays(-1);

            string DateArrived = TestDate.ToString();

            Error = AStock.Valid(SupplierAddress, StockDescription, StockSupplier, DateArrived);

            Assert.AreNotEqual(Error, "");

        }

        [TestMethod]

        public void DateArrivedMin()
        {

            clsStock AStock = new clsStock();

            String Error = "";

            DateTime TestDate;

            TestDate = DateTime.Now.Date;

            string DateArrived = TestDate.ToString();

            Error = AStock.Valid(SupplierAddress, StockDescription, StockSupplier, DateArrived);

            Assert.AreEqual(Error, "");

        }

        [TestMethod]

        public void DateArrivedMinPlusOne()
        {

            clsStock AStock = new clsStock();

            string Error = "";

            DateTime TestDate;

            TestDate = DateTime.Now.Date;

            TestDate = TestDate.AddDays(1);

            string DateArrived = TestDate.ToString();

            Error = AStock.Valid(SupplierAddress, StockDescription, StockSupplier, DateArrived);

            Assert.AreNotEqual(Error, "");




        }

        [TestMethod]

        public void DateArrivedExtremeMax()
        {

            clsStock AStock = new clsStock();

            String Error = "";

            DateTime TestDate;

            TestDate = DateTime.Now.Date;

            TestDate = TestDate.AddYears(100);

            string DateArrived = TestDate.ToString();

            Error = AStock.Valid(SupplierAddress, StockDescription, StockSupplier, DateArrived);

            Assert.AreNotEqual(Error, "");

        }

        [TestMethod]

        public void DateArrivedInvalidData()
        {

            clsStock AStock = new clsStock();

            string Error = "";

            string DateArrived = "this is not a date!";

            Error = AStock.Valid(SupplierAddress, StockDescription, StockSupplier, DateArrived);

            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]

        public void StockSupplierMinLessOne()
        {

            clsStock AStock = new clsStock();

            string Error = "";

            string StockSupplier = "";

            Error = AStock.Valid(SupplierAddress, StockDescription, StockSupplier, DateArrived);

            Assert.AreNotEqual(Error, "");

        }

        [TestMethod]

        public void StockSupplierMin()

        {

            clsStock AStock = new clsStock();

            string Error = "";

            string StockSupplier = "a";

            Error = AStock.Valid(SupplierAddress, StockDescription, StockSupplier, DateArrived);

            Assert.AreEqual(Error, "");
        }

        [TestMethod]

        public void StockSupplierMinPlusOne()
        {
            clsStock AStock = new clsStock();

            String Error = "";

            string StockSupplier = "aa";

            Error = AStock.Valid(SupplierAddress, StockDescription, StockSupplier, DateArrived);

            Assert.AreEqual(Error, "");

        }

        [TestMethod]

        public void StockSupplierMaxLessOne()
        {

            clsStock AStock = new clsStock();

            String Error = "";

            string StockSupplier = "";

            StockSupplier = StockSupplier.PadRight(49, 'a');

            Error = AStock.Valid(SupplierAddress, StockDescription, StockSupplier, DateArrived);

            Assert.AreNotEqual(Error, "");

        }

        [TestMethod]

        public void StockSupplierMax()
        {

            clsStock AStock = new clsStock();

            string Error = "";

            string StockSupplier = "";

            StockSupplier = StockSupplier.PadRight(50, 'a');

            Error = AStock.Valid(SupplierAddress, StockDescription, StockSupplier, DateArrived);

            Assert.AreEqual(Error, "");

        }

        [TestMethod]

        public void StockSupplierMaxPlusOne()
        {

            clsStock AStock = new clsStock();

            String Error = "";

            String StockSupplier = "";

            Error = AStock.Valid(SupplierAddress, StockDescription, StockSupplier, DateArrived);

            Assert.AreNotEqual(Error, "");

        }

        [TestMethod]

        public void StockSupplierMid()
        {

            clsStock AStock = new clsStock();

            String Error = "";

            string StockSupplier = "";

            StockSupplier = StockSupplier.PadRight(25, 'a');

            Error = AStock.Valid(SupplierAddress, StockDescription, StockSupplier, DateArrived);

            Assert.AreEqual(Error, "");

        }

        [TestMethod]

        public void StockDescriptionMin()
        {

            clsStock AStock = new clsStock();

            String Error = "";

            string StockDescription = "a";

            Error = AStock.Valid(SupplierAddress, StockDescription, StockSupplier, DateArrived);

            Assert.AreEqual(Error, "");

        }

        [TestMethod]

        public void StockDescriptionMinPlusOne()
        {

            clsStock AStock = new clsStock();

            String Error = "";

            string StockDescription = "aa";

            Error = AStock.Valid(SupplierAddress, StockDescription, StockSupplier, DateArrived);

            Assert.AreEqual(Error, "");

        }

        [TestMethod]

        public void StockDescriptionMaxLessOne()
        {

            clsStock AStock = new clsStock();

            String Error = "";

            string StockDescription = "";

            StockDescription = StockDescription.PadRight(49, 'a');

            Error = AStock.Valid(SupplierAddress, StockDescription, StockSupplier, DateArrived);

            Assert.AreEqual(Error, "");

        }

        [TestMethod]

        public void StockDescriptionMax()
        {

            clsStock AStock = new clsStock();

            String Error = "";

            string StockDescription = "";

            StockDescription = StockDescription.PadRight(50, 'a');

            Error = AStock.Valid(SupplierAddress, StockDescription, StockSupplier, DateArrived);

            Assert.AreEqual(Error, "");

        }

        [TestMethod]

        public void StockDescriptionMaxPlusOne()
        {

            clsStock AStock = new clsStock();

            String Error = "";

            string StockDescription = "";

            StockDescription = StockDescription.PadRight(51, 'a');

            Error = AStock.Valid(SupplierAddress, StockDescription, StockSupplier, DateArrived);

            Assert.AreNotEqual(Error, "");

        }

        [TestMethod]

        public void StockDescriptionMid()
        {
            clsStock AStock = new clsStock();

            String Error = "";

            string StockDescription = "";

            StockDescription = StockDescription.PadRight(25, 'a');

            Error = AStock.Valid(SupplierAddress, StockDescription, StockSupplier, DateArrived);

            Assert.AreEqual(Error, "");



        }




    }
}



       

       







    
