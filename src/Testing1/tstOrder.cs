using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace tstOrder
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
            clsOrder bOrder = new clsOrder();;
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
    }
}
