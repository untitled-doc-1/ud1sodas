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

            clsStock AStock = new clsStock();

            Assert.IsNotNull(AStock);


        }

        [TestMethod]

        public void ActivePropertyOK()
        {

            clsStock AStock = new clsStock();

            Boolean TestData = true;

            AStock.Active = TestData;
            //Assign Data

            Assert.AreEqual(AStock.Active, TestData);



        }

        [TestMethod]

        public void DateArrived()
        {
            clsStock AStock = new clsStock();

            DateTime TestData = DateTime.Now.Date;

            AStock.DateAdded = TestData;

            Assert.AreEqual(AStock.DateAdded, TestData);


        }










    }
}
