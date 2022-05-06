using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace OrderTests
{
    [TestClass]
    public class tstOrder
    {
        /*
         *  
         *       OrderID		Int		    Primary Key
         *       OrderTotal		Double
         *       Description	String
         *       TotalItems		Int
         *       DatePlaced		Date
         *       Fulfilled		Bool
         * 
         * 
         */
        private static clsOrder[] arr = Array.Empty<clsOrder>();

        [TestMethod]
        public void InstanceOK()
        {
            //create an instance of the class
            clsOrder exampleOrder = new clsOrder();
            //test for existance
            Assert.IsNotNull(exampleOrder);
        }

        //[TestMethod]
        //public void IDIncrementOK()
        //{
        //    clsOrder.IDCounter = 0;
        //    clsOrder order1 = new clsOrder();
        //    Assert.AreEqual(0, order1.ID);
        //}

        [TestMethod]
        public void OrderIDPropertyOK()
        {
            clsOrder order1 = new clsOrder();
            clsOrder order2 = new clsOrder();
            Assert.AreEqual(order1.ID, order2.ID);
        }

        [TestMethod]
        public void OrderTotalPropertyOK()
        {
            clsOrder aOrder = new clsOrder();
            aOrder.TotalItems = 2;

            Assert.AreEqual(aOrder.TotalItems, 2);
        }


        [TestMethod]
        public void DescriptionPropertyOK()
        {
            clsOrder order1 = new clsOrder();
            order1.Description = "Baked beans, sausages, eggs, tomatoes, bread and bacon";
            string expected = "Baked beans, sausages, eggs, tomatoes, bread and bacon";
            Assert.AreEqual(order1.Description, expected);
        }


        [TestMethod]
        public void TotalItemsPropertyOK()
        {
            clsOrder aOrder = new clsOrder();
            clsOrder bOrder = new clsOrder(); ;
            aOrder.TotalItems = 3;
            bOrder.TotalItems = 3;
            Assert.AreEqual(aOrder.TotalItems, bOrder.TotalItems);
        }

        [TestMethod]
        public void DatePlacedPropertyOK()
        {
            clsOrder order1 = new clsOrder();
            order1.DatePlaced = DateTime.Now;
            Assert.AreEqual(order1.DatePlaced.Date, DateTime.Now.Date);
        }

        [TestMethod]
        public void FulfilledPropertyOK()
        {
            clsOrder aOrder = new clsOrder();
            aOrder.Fulfillment_status = true;
            Assert.IsTrue(aOrder.Fulfillment_status);
        }


        //     Field test values        

        /*
        * 
        * ExMin - Extreme Minimum
        * MinM1 - Minimum minus 1
        * Min - Minimum
        * MinP1 - Minimum plus 1
        * Mid - Middle
        * MaxM1 - maximum minus 1
        * Max - Maximum
        * MaxP1 - maximum plus 1
        * ExMax - extreme maximum
        * IDT - Invalid data type
        *
        */



        private string Description = "Green eggs & Ham with a side of imbecility";
        private string totalItems = "25";
        private string totalCost = "50.00";
        private string datePlaced = DateTime.Now.Date.ToString();


        //     Order Date Placed


        [TestMethod]
        public void DatePlacedExMin()
        {
            clsOrder exOrder = new clsOrder();
            string strDPlaced = "01/01/0001";
            string Error = exOrder.Validate(Description, totalCost, totalItems, strDPlaced);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void DatePlacedMinM1()
        {
            clsOrder exOrder = new clsOrder();
            // Last week, should fail
            DateTime erDT = DateTime.Now.AddDays(-1);
            string strDPlaced = erDT.Date.ToString();
            string Error = exOrder.Validate(Description, totalCost, totalItems, strDPlaced);
            Assert.AreNotEqual(Error, "");
        }
        [TestMethod]
        public void DatePlacedMin()
        {
            clsOrder exOrder = new clsOrder();
            string strDPlaced = DateTime.Now.Date.ToString();
            string Error = exOrder.Validate(Description, totalCost, totalItems, strDPlaced);
            Assert.AreEqual(Error, "");
        }
        [TestMethod]
        public void DatePlacedMinP1()
        {
            clsOrder exOrder = new clsOrder();
            string strDPlaced = DateTime.Now.Date.AddDays(1).Date.ToString();
            string Error = exOrder.Validate(Description, totalCost, totalItems, strDPlaced);
            Assert.AreNotEqual(Error, "");
        }
        [TestMethod]
        public void DatePlacedMid()
        {
            clsOrder exOrder = new clsOrder();
            string strDPlaced = DateTime.Now.Date.ToString();
            string Error = exOrder.Validate(Description, totalCost, totalItems, strDPlaced);
            Assert.AreEqual(Error, "");
        }
        [TestMethod]
        public void DatePlacedMaxM1()
        {
            clsOrder exOrder = new clsOrder();
            string strDPlaced = DateTime.Now.Date.AddDays(-1).Date.ToString();
            string Error = exOrder.Validate(Description, totalCost, totalItems, strDPlaced);
            Assert.AreNotEqual(Error, "");
        }
        [TestMethod]
        public void DatePlacedMax()
        {
            clsOrder exOrder = new clsOrder();
            string strDPlaced = DateTime.Now.Date.ToString();
            string Error = exOrder.Validate(Description, totalCost, totalItems, strDPlaced);
            Assert.AreEqual(Error, "");
        }
        [TestMethod]
        public void DatePlacedMaxP1()
        {
            clsOrder exOrder = new clsOrder();
            string strDPlaced = DateTime.Now.Date.AddDays(1).Date.ToString();
            string Error = exOrder.Validate(Description, totalCost, totalItems, strDPlaced);
            Assert.AreNotEqual(Error, "");
        }
        [TestMethod]
        public void DatePlacedExMax()
        {
            clsOrder exOrder = new clsOrder();
            string strDPlaced = "31/12/3022";
            string Error = exOrder.Validate(Description, totalCost, totalItems, strDPlaced);
            Assert.AreNotEqual(Error, "");
        }
        [TestMethod]
        public void DatePlacedIDT()
        {
            clsOrder exOrder = new clsOrder();
            string strDPlaced = "420.69";
            string Error = exOrder.Validate(Description, totalCost, totalItems, strDPlaced);
            Assert.AreNotEqual(Error, "");
        }


        //     Order Total Cost         


        [TestMethod]
        public void TCostExMin()
        {
            clsOrder exOrder = new clsOrder();
            string strTotalCost = Decimal.MinValue.ToString();
            string Error = exOrder.Validate(Description, strTotalCost, totalItems, datePlaced);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void TCostMinM1()
        {
            clsOrder exOrder = new clsOrder();
            string strTCost = "-1";
            string Error = exOrder.Validate(Description, strTCost, totalItems, datePlaced);
            Assert.AreNotEqual(Error, "");
        }
        [TestMethod]
        public void TCostMin()
        {
            clsOrder exOrder = new clsOrder();
            string strTCost = "1";
            string Error = exOrder.Validate(Description, strTCost, totalItems, datePlaced);
            Assert.AreEqual(Error, "");
        }
        [TestMethod]
        public void TCostMinP1()
        {
            clsOrder exOrder = new clsOrder();
            string strTCost = "2";
            string Error = exOrder.Validate(Description, strTCost, totalItems, datePlaced);
            Assert.AreEqual(Error, "");
        }
        [TestMethod]
        public void TCostMid()
        {
            clsOrder exOrder = new clsOrder();
            string strTCost = "20983.53";
            string Error = exOrder.Validate(Description, strTCost, totalItems, datePlaced);
            Assert.AreEqual(Error, "");
        }
        [TestMethod]
        public void TCostMaxM1()
        {
            clsOrder exOrder = new clsOrder();
            string strTCost = (50000.99M - 1).ToString();
            string Error = exOrder.Validate(Description, strTCost, totalItems, datePlaced);
            Assert.AreEqual(Error, "");
        }
        [TestMethod]
        public void TCostMax()
        {
            clsOrder exOrder = new clsOrder();
            string strTCost = "50000.00";
            string Error = exOrder.Validate(Description, strTCost, totalItems, datePlaced);
            Assert.AreEqual(Error, "");
        }
        [TestMethod]
        public void TCostMaxP1()
        {
            clsOrder exOrder = new clsOrder();
            string strTCost = (50001.99M).ToString();
            string Error = exOrder.Validate(Description, strTCost, totalItems, datePlaced);
            Assert.AreNotEqual(Error, "");
        }
        [TestMethod]
        public void TCostExMax()
        {
            clsOrder exOrder = new clsOrder();
            string strTCost = Decimal.MaxValue.ToString();
            string Error = exOrder.Validate(Description, strTCost, totalItems, datePlaced);
            Assert.AreNotEqual(Error, "");
        }
        [TestMethod]
        public void TCostIDT()
        {
            clsOrder exOrder = new clsOrder();
            string strTCost = "green eggs & ham";
            string Error = exOrder.Validate(Description, strTCost, totalItems, datePlaced);
            Assert.AreNotEqual(Error, "");
        }


        //     Order Total Items


        [TestMethod]
        public void TItemsExMin()
        {
            clsOrder exOrder = new clsOrder();
            string strTItems = Int32.MinValue.ToString();
            string Error = exOrder.Validate(Description, totalCost, strTItems, datePlaced);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void TItemsMinM1()
        {
            clsOrder exOrder = new clsOrder();
            string strTItems = 0.ToString();
            string Error = exOrder.Validate(Description, totalCost, strTItems, datePlaced);
            Assert.AreNotEqual(Error, "");
        }
        [TestMethod]
        public void TItemsMin()
        {
            clsOrder exOrder = new clsOrder();
            string strTItems = 1.ToString();
            string Error = exOrder.Validate(Description, totalCost, strTItems, datePlaced);
            Assert.AreEqual(Error, "");
        }
        [TestMethod]
        public void TItemsMinP1()
        {
            clsOrder exOrder = new clsOrder();
            string strTItems = 2.ToString();
            string Error = exOrder.Validate(Description, totalCost, strTItems, datePlaced);
            Assert.AreEqual(Error, "");
        }
        [TestMethod]
        public void TItemsMid()
        {
            clsOrder exOrder = new clsOrder();
            string strTItems = 500.ToString();
            string Error = exOrder.Validate(Description, totalCost, strTItems, datePlaced);
            Assert.AreEqual(Error, "");
        }
        [TestMethod]
        public void TItemsMaxM1()
        {
            clsOrder exOrder = new clsOrder();
            string strTItems = 999.ToString();
            string Error = exOrder.Validate(Description, totalCost, strTItems, datePlaced);
            Assert.AreEqual(Error, "");
        }
        [TestMethod]
        public void TItemsMax()
        {
            clsOrder exOrder = new clsOrder();
            string strTItems = 1000.ToString();
            string Error = exOrder.Validate(Description, totalCost, strTItems, datePlaced);
            Assert.AreEqual(Error, "");
        }
        [TestMethod]
        public void TItemsMaxP1()
        {
            clsOrder exOrder = new clsOrder();
            string strTItems = 1001.ToString();
            string Error = exOrder.Validate(Description, totalCost, strTItems, datePlaced);
            Assert.AreNotEqual(Error, "");
        }
        [TestMethod]
        public void TItemsExMax()
        {
            clsOrder exOrder = new clsOrder();
            string strTItems = Int32.MaxValue.ToString();
            string Error = exOrder.Validate(Description, totalCost, strTItems, datePlaced);
            Assert.AreNotEqual(Error, "");
        }
        [TestMethod]
        public void TItemsIDT()
        {
            clsOrder exOrder = new clsOrder();
            string strTItems = "Huh, where's all the valid test data gone?";
            string Error = exOrder.Validate(Description, totalCost, strTItems, datePlaced);
            Assert.AreNotEqual(Error, "");
        }


        //     Order Description


        [TestMethod]
        public void DescExMin()
        {
            clsOrder exOrder = new clsOrder();
            string strDesc = "";
            string Error = exOrder.Validate(strDesc, totalCost, totalItems, datePlaced);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void DescMinM1()
        {
            clsOrder exOrder = new clsOrder();
            string strDesc = "";
            string Error = exOrder.Validate(strDesc, totalCost, totalItems, datePlaced);
            Assert.AreNotEqual(Error, "");
        }
        [TestMethod]
        public void DescMin()
        {
            clsOrder exOrder = new clsOrder();
            string strDesc = "lol";
            string Error = exOrder.Validate(strDesc, totalCost, totalItems, datePlaced);
            Assert.AreEqual(Error, "");
        }
        [TestMethod]
        public void DescMinP1()
        {
            clsOrder exOrder = new clsOrder();
            string strDesc = "lmao";
            string Error = exOrder.Validate(strDesc, totalCost, totalItems, datePlaced);
            Assert.AreEqual(Error, "");
        }
        [TestMethod]
        public void DescMid()
        {
            clsOrder exOrder = new clsOrder();
            string strDesc = "Green eggs & ham with a side of .NET";
            string Error = exOrder.Validate(strDesc, totalCost, totalItems, datePlaced);
            Assert.AreEqual(Error, "");
        }
        [TestMethod]
        public void DescMaxM1()
        {
            clsOrder exOrder = new clsOrder();
            string strDesc = "Llanfair­pwllgwyngyll­gogery­chwyrn­drobwll­llan";
            string Error = exOrder.Validate(strDesc, totalCost, totalItems, datePlaced);
            Assert.AreEqual(Error, "");
        }
        [TestMethod]
        public void DescMax()
        {
            clsOrder exOrder = new clsOrder();
            string strDesc = "Llanfairpwllgwyngyllgogerychwyrndrobwllllant";
            string Error = exOrder.Validate(strDesc, totalCost, totalItems, datePlaced);
        }
        [TestMethod]
        public void DescMaxP1()
        {
            clsOrder exOrder = new clsOrder();
            string strDesc = "Llanfairpwllgwyngyllgogerychwyrndrobwllllanty";
            string Error = exOrder.Validate(strDesc, totalCost, totalItems, datePlaced);
        }
        [TestMethod]
        public void DescExMax()
        {
            clsOrder exOrder = new clsOrder();
            string strDesc = "Llanfair­pwllgwyngyll­gogery­chwyrn­drobwll­llan­tysilio­gogo­goch";
            string Error = exOrder.Validate(strDesc, totalCost, totalItems, datePlaced);
            Assert.AreNotEqual(Error, "");
        }
        /// <summary>
        /// Not applicable to type string
        /// </summary>
        [TestMethod]
        public void DescIDT()
        {
            Assert.IsTrue(true);
        }


        //     Order Collections


        [TestMethod]
        public void CollectionInstanceOK()
        {
            clsOrderCollection AllOrders = new clsOrderCollection();
            Assert.IsNotNull(AllOrders);
        }

        [TestMethod]
        public void OrderListOK()
        {
            clsOrderCollection AllOrders = new clsOrderCollection();
            List<clsOrder> exList = new List<clsOrder>();
            clsOrder exOrder = new clsOrder();

            exOrder.Fulfillment_status = true;
            exOrder.DatePlaced = DateTime.Now.Date;
            exOrder.Description = "Green eggs & ham with a side of .NET";
            exOrder.ID = 1;
            exOrder.TotalItems = 25;
            exOrder.TotalCost = 2000.00M;
            exList.Add(exOrder);
            AllOrders.OrdersList = exList;
            Assert.AreEqual(AllOrders.OrdersList, exList);

        }

        [TestMethod]
        public void ThisOrderPropertyOK()
        {
            clsOrderCollection AllOrders = new clsOrderCollection();
            clsOrder exOrder = new clsOrder();
            exOrder.Fulfillment_status = true;
            exOrder.DatePlaced = DateTime.Now.Date;
            exOrder.Description = "Green eggs & ham with a side of .NET";
            exOrder.ID = 1;
            exOrder.TotalItems = 5;
            exOrder.TotalCost = 2000.00M;
            AllOrders.ThisOrder = exOrder;
            Assert.AreEqual(AllOrders.ThisOrder, exOrder);

        }

        [TestMethod]
        public void ListAndCountOK()
        {
            clsOrderCollection AllOrders = new clsOrderCollection();
            List<clsOrder> exList = new List<clsOrder>();
            clsOrder exOrder = new clsOrder();
            exOrder.Fulfillment_status = true;
            exOrder.DatePlaced = DateTime.Now.Date;
            exOrder.Description = "Green eggs & ham with a side of .NET";
            exOrder.ID = 1;
            exOrder.TotalItems = 5;
            exOrder.TotalCost = 2000.00M;
            exList.Add(exOrder);
            AllOrders.OrdersList = exList;
            Assert.AreEqual(AllOrders.Count, exList.Count);

        }

        [TestMethod]

        public void AddMethodOK()
        {
            clsOrderCollection AllOrders = new clsOrderCollection();
            clsOrder exOrder = new clsOrder();
            Int32 PrimaryKey = 0;
            exOrder.Fulfillment_status = true;
            exOrder.DatePlaced = DateTime.Now.Date;
            exOrder.Description = "Green eggs & ham with a side of .NET";
            exOrder.ID = 1;
            exOrder.TotalItems = 5;
            exOrder.TotalCost = 2000.00M;
            AllOrders.ThisOrder = exOrder;
            PrimaryKey = AllOrders.Add();
            exOrder.ID = PrimaryKey;
            AllOrders.ThisOrder.Find(PrimaryKey);
            Assert.AreEqual(AllOrders.ThisOrder, exOrder);
        }

        [TestMethod]
        public void UpdateMethod()
        {
            clsOrderCollection AllOrders = new clsOrderCollection();
            clsOrder exOrder = new clsOrder();
            Int32 PrimaryKey;
            exOrder.Fulfillment_status = true;
            exOrder.DatePlaced = DateTime.Now.Date;
            exOrder.Description = "Green eggs & ham with a side of .NET";
            exOrder.ID = 1;
            exOrder.TotalItems = 5;
            exOrder.TotalCost = 2000.00M;
            AllOrders.ThisOrder = exOrder;
            PrimaryKey = AllOrders.Add();
            exOrder.ID = PrimaryKey;

            // Modifying the test data
            exOrder.Fulfillment_status = true;
            exOrder.DatePlaced = DateTime.Now.Date;
            exOrder.Description = "test value go brrr";
            exOrder.ID = 1;
            exOrder.TotalItems = 5;
            exOrder.TotalCost = 2600.00M;

            // Setting the record based on the new test data 
            AllOrders.ThisOrder = exOrder;
            // Updating the original record
            AllOrders.Update();
            // Find the record from the Primary Key
            AllOrders.ThisOrder.Find(PrimaryKey);
            // Testing to see if ThisOrder matches the test data
            Assert.AreEqual(AllOrders.ThisOrder, exOrder);
        }

        [TestMethod]
        public void DeleteMethodOK()
        {
            clsOrderCollection AllOrders = new clsOrderCollection();
            clsOrder exOrder = new clsOrder();

            //Declare the Primary Key
            Int32 PrimaryKey;

            // Set the example Order's properties
            exOrder.Fulfillment_status = true;
            exOrder.DatePlaced = DateTime.Now.Date;
            exOrder.Description = "test value go brrr";
            exOrder.ID = 1;
            exOrder.TotalItems = 5;
            exOrder.TotalCost = 2600.00M;
            AllOrders.ThisOrder = exOrder;
            PrimaryKey = AllOrders.Add();

            exOrder.ID = PrimaryKey;
            AllOrders.ThisOrder.Find(PrimaryKey);
            // Delete the record
            AllOrders.Delete();
            // Now try finding the record again, should fail
            bool Found = AllOrders.ThisOrder.Find(PrimaryKey);
            // Test to see if the record is not found
            Assert.IsFalse(Found);
        }

        [TestMethod]
        public void ReportByFulfilmentStatusOK()
        {
            //creating an instance of the class 
            clsOrderCollection AllOrders = new clsOrderCollection();
            //creating an instance of the filtered data
            clsOrderCollection FilteredOrder = new clsOrderCollection();
            //applying a blank string (should return all records);
            FilteredOrder.ReportByFulfilmentStatus(false);
            //testing to see that both values are the same
            Assert.AreNotEqual(AllOrders.Count, FilteredOrder.Count);
        }

        [TestMethod]
        public void ReportByDescNoneFound()
        {
            //creating an instance of the filtered data
            clsOrderCollection FilteredOrder = new clsOrderCollection();
            //applying an employee name that doesn't exist
            FilteredOrder.ReportByDescr("Windows 98SE");
            //testing to see that there are no such record
            Assert.AreEqual(0, FilteredOrder.Count);
        }
    }
}
