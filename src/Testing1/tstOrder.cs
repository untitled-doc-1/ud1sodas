using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Testing1
{
    [TestClass]
    public class tstOrder
    {
        /*
         *  
OrderID		    Int		    Primary Key
OrderTotal		Double
Description		String
TotalItems		Int
DatePlaced		Date
Fulfilled		Bool
 
         * 
         * 
         */
        private static clsOrder[] arr = Array.Empty<clsOrder>();

        [TestMethod]
        public void InstanceOK()
        {
            //create an instance of the class
            clsOrder exampleOrder = new clsOrder("InstanceOK", arr);
            //test for existance
            Assert.IsNotNull(exampleOrder);
        }

        [TestMethod]
        public void IDIncrementOK()
        {
            clsOrder.IDCounter = 0;
            clsOrder order1 = new clsOrder("", arr);
            Assert.AreEqual(0, order1.ID);
        }

        [TestMethod]
        public void OrderIDPropertyOK()
        {
            clsOrder.IDCounter = 0;
            clsOrder order1 = new clsOrder("", arr);
            int num = order1.ID + 1;
            clsOrder order2 = new clsOrder("", arr);
            Assert.AreEqual(num, order2.ID);
        }

        [TestMethod]
        public void OrderTotalPropertyOK()
        {
            clsOrder[] arrOrder = new clsOrder[2]
            {
                new clsOrder("arrOrder1", arr),
                new clsOrder("arrOrder2", arr)
            };
            clsOrder aOrder = new clsOrder("ExampleOrderLine", arr);
            clsOrder bOrder = new clsOrder("Example B OrderLine", arrOrder);

            Assert.AreEqual(aOrder.TotalCost * 2, bOrder.TotalCost);
        }


        [TestMethod]
        public void DescriptionPropertyOK()
        {
            clsOrder order1 = new clsOrder("Baked beans, sausages, eggs, tomatoes, bread and bacon", arr);
            string expected = "Baked beans, sausages, eggs, tomatoes, bread and bacon";
            Assert.AreEqual(order1.GetDescription(), expected);
        }


        [TestMethod]
        public void TotalItemsPropertyOK()
        {
            clsOrder[] arrOrder = new clsOrder[2]
            {
                new clsOrder("arrOrder1", arr),
                new clsOrder("arrOrder2", arr)
            };
            clsOrder order1 = new clsOrder("Example", arrOrder);
            Assert.AreEqual(order1.GetTotalItems(), 2);
        }

        [TestMethod]
        public void DatePlacedPropertyOK()
        {
            clsOrder order1 = new clsOrder("example clsOrder", arr);
            Assert.AreEqual(order1.GetDatePlaced().Date, DateTime.Now.Date);
        }

        [TestMethod]
        public void FulfilledPropertyOK()
        {
            clsOrder aOrder = new clsOrder("Example Order", arr);
            aOrder.CompleteOrder();
            Assert.IsTrue(aOrder.GetFulfillment_status());
        }
    }
}
