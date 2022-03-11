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
        public void EmployeeIdPropertyOK()
        {
            //create an instance of the class
            clsStaff AStaff = new clsStaff();
            //data test
            Int32 DataTest = 1;
            // assign the datatest for the property
            AStaff.EmployeeId = DataTest;
            // test that both values are the same
            Assert.AreEqual(AStaff.EmployeeId, DataTest);
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
            Int32 EmployeeId = 2;
            //invoking the find method
            Found = AStaff.Find(EmployeeId);
            //testing the result
            Assert.IsTrue(Found);


        }

        [TestMethod]
        public void TestEmplyeeIdFound()
        {
            //creating an instance of the class
            clsStaff AStaff = new clsStaff();
            //boolean variable to store the result of the search
            Boolean Found = false;
            //boolean variable to record if the value is okay (assume it is)
            Boolean OK = true;
            //creat some test data to use with the method
            Int32 EmployeeId = 3;
            //invoke the method
            Found = AStaff.Find(EmployeeId);
            //check the EmployeeId
            if (AStaff.EmployeeId != 3)
            {
                OK = false;
            }
            //test to see that the result is correct
            Assert.IsTrue(OK);

        }

        [TestMethod]
        public void TestActiveFound()
        {
            //create an instance od the class
            clsStaff AStaff = new clsStaff();
            //boolean variable to store the result of the search
            Boolean Found = false;
            //boolean variable to record if the data is okay
            Boolean OK = true;
            //creat some test data
            Int32 EmployeeId = 1;
            //invoke the method
            Found = AStaff.Find(EmployeeId);
            //check the property
            if (AStaff.Active != true)
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
            Int32 EmployeeId = 1;
            //invoke the method
            Found = AStaff.Find(EmployeeId);
            //check the property
            if (AStaff.DateHired != Convert.ToDateTime("1/1/2013"))
            {
                OK = false;
            }
            //test to see that the result is correct
            Assert.IsTrue(OK);
        }

        [TestMethod]
        public void TestSalaryFound()
        {
            //creating an instance of the class
            clsStaff AStaff = new clsStaff();
            //boolean variable to store the result of the search
            Boolean Found = false;
            //boolean variable to record if the value is okay (assume it is)
            Boolean OK = true;
            //creat some test data to use with the method
            Int32 EmployeeId = 4;
            //invoke the method
            Found = AStaff.Find(EmployeeId);
            //check the EmployeeId
            if (AStaff.Salary != 2500)
            {
                OK = false;
            }
            //test to see that the result is correct
            Assert.IsTrue(OK);

        }

        [TestMethod]
        public void TestEmpFullNameFound()
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
            if (AStaff.EmpFullName != "Nora Alen")
            {
                OK = false;
            }
            //test to see that the result is correct
            Assert.IsTrue(OK);

        }

        [TestMethod]
        public void TestJobDescriptionPermissionsFound()
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
            if (AStaff.JobDescriptionPermissions != "Marketing")
            {
                OK = false;
            }
            //test to see that the result is correct
            Assert.IsTrue(OK);

        }


    }
}
