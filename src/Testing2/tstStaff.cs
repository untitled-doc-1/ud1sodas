﻿using ClassLibrary;
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
        public void PermissionsPropertyOK()
        {
            //create an instance of the class
            clsStaff AStaff = new clsStaff();
            //data test
            String DataTest = "Read Only";
            // assign the datatest for the property
            AStaff.Permissions = DataTest;
            // test that both values are the same
            Assert.AreEqual(AStaff.Permissions, DataTest);
        }

        [TestMethod]
        public void JobDescriptionPropertyOK()
        {
            //create an instance of the class
            clsStaff AStaff = new clsStaff();
            //data test
            String DataTest = "Data Entry";
            // assign the datatest for the property
            AStaff.JobDescription = DataTest;
            // test that both values are the same
            Assert.AreEqual(AStaff.JobDescription, DataTest);
        }



    }
}
