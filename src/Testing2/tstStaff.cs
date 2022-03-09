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

        [TestMethod]
        public void ActivePropertyOK()
        {
            //create an instance of the class
            clsStaff AStaff = new clsStaff();
            //data test
            Boolean DataTest = true;
            // assign the datatest for the property
            AStaff.Active = DataTest;
            // test that both values are the same
            Assert.AreEqual(AStaff.Active, DataTest);
        }

        [TestMethod]
        public void DateHiredPropertyOK()
        {
            //create an instance of the class
            clsStaff AStaff = new clsStaff();
            //data test
            DateTime DataTest = DateTime.Now.Date;
            // assign the datatest for the property
            AStaff.DateHired = DataTest;
            // test that both values are the same
            Assert.AreEqual(AStaff.DateHired, DataTest);
        }

        [TestMethod]
        public void EmployeeIDPrimaryPropertyOK()
        {
            //create an instance of the class
            clsStaff AStaff = new clsStaff();
            //data test
            Int32 DataTest = 1;
            // assign the datatest for the property
            AStaff.EmployeeIDPrimary = DataTest;
            // test that both values are the same
            Assert.AreEqual(AStaff.EmployeeIDPrimary, DataTest);
        }

        [TestMethod]
        public void SalaryPropertyOK()
        {
            //create an instance of the class
            clsStaff AStaff = new clsStaff();
            //data test
            Double DataTest = 2000.55;
            // assign the datatest for the property
            AStaff.Salary = DataTest;
            // test that both values are the same
            Assert.AreEqual(AStaff.Salary, DataTest);
        }

        [TestMethod]
        public void EmpFullNamePropertyOK()
        {
            //create an instance of the class
            clsStaff AStaff = new clsStaff();
            //data test
            String DataTest = "Eddie Morra";
            // assign the datatest for the property
            AStaff.EmpFullName = DataTest;
            // test that both values are the same
            Assert.AreEqual(AStaff.EmpFullName, DataTest);
        }

        [TestMethod]
        public void JobDescriptionPermissionsPropertyOK()
        {
            //create an instance of the class
            clsStaff AStaff = new clsStaff();
            //data test
            String DataTest = "Data Entry / Read Only";
            // assign the datatest for the property
            AStaff.JobDescriptionPermissions = DataTest;
            // test that both values are the same
            Assert.AreEqual(AStaff.JobDescriptionPermissions, DataTest);
        }

        [TestMethod]

        public void FindMethodOK()
        {
            //creating an instance of the class
            clsStaff AStaff = new clsStaff();
            //Boolean variable stored for validation
            Boolean Found = false;
            //creating test data for the method
            Int32 EmployeeId = 1;
            //invoking the find method
            Found = AStaff.Find(EmployeeId);
            //testing the result
            Assert.IsTrue(Found);


        }

        [TestMethod]
        public void testEmplyeeIdFound()
        {
            //creating an instance of the class
            clsStaff AStaff = new clsStaff();
            //boolean variable to store the result of the search
            Boolean Found = false;
            //boolean variable to record if the value is okay (assume it is)
            Boolean OK = true;
            //creat some test data to use with the method
            Int32 EmployeeId = 2;
            //invoke the method
            Found = AStaff.Find(EmployeeId);
            //check the EmployeeId
            if (AStaff.EmployeeIDPrimary != 2)
            {
                OK = false;
            }
            //test to see that the result is correct
            Assert.IsTrue(OK);

        }

        [TestMethod]
        public void TestDateHiredFound()
        {
            //create an instance od the class
            clsStaff AStaff = new clsStaff();
            //boolean variable to store the result of the search
            Boolean Found = false;
            //boolean variable to record if the data is okay
            Boolean OK = true;
            //creat some test data
            Int32 EmployeeId = 2;
            //invoke the method
            Found = AStaff.Find(EmployeeId);
            //check the property
            if (AStaff.DateHired != Convert.ToDateTime("16/09/2015"))
            {
                OK = false;
            }
            //test to see that the result is correct
            Assert.IsTrue(OK);
        }
    }
}
