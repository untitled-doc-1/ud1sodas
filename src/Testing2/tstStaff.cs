using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Testing2
{
    [TestClass]
    public class tstStaff
    {
        [TestMethod]
        public void InstanceOK()
        {
            //create an instance of the class
            clsStaff AStaff = new clsStaff();
            //test for existance
            Assert.IsNotNull(AStaff);
        }
    }
}
