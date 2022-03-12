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

            clsStock AnStock = new clsStock();

            Assert.IsNotNull(AnStock);


        }
    }
}
