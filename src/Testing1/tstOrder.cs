using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Testing1
{
    [TestClass]
    public class tstOrder
    {
        [TestMethod]
        public void InstanceOK()
        {
            //create an instance of the class
            clsOrder exampleOrder = new clsOrder(1, "InstanceOK", null);
            //test for existance
            Assert.IsNotNull(exampleOrder);
        }

        [TestMethod]
        public void DefaultValue()
        {
            clsOrder[] arrOrder = new clsOrder[2]
            {
                new clsOrder(5, "arrOrder1", null),
                new clsOrder(10, "arrOrder2", null)
            };
            clsOrder aOrder = new clsOrder(0, "ExampleOrderLine", null);
            clsOrder bOrder = new clsOrder(1, "Example B OrderLine", arrOrder);

            Assert.AreEqual(aOrder.TotalCost * 2, bOrder.TotalCost);
        }
    }
}
