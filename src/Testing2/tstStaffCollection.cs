using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Testing2
{
    [TestClass]
    public class tstStaffCollection
    {
        [TestMethod]
        public void InstanceOK()
        {
            //create an instance of the calss
            clsStaffCollection AllStaffMembers = new clsStaffCollection();
            //test to see if it exists
            Assert.IsNotNull(AllStaffMembers);
        }

        [TestMethod]
        public void StaffListOK()
        {
            //creating an instance of the class
            clsStaffCollection AllStaffMembers = new clsStaffCollection();
            //creating some test data to assign to the property
            //the data needs to be a list of objects 
            List<clsStaff> TestList = new List<clsStaff>();
            //creating the item and adding it to the list
            clsStaff TestItem = new clsStaff();
            //setting the properties of the item
            TestItem.Active = true;
            TestItem.DateHired = DateTime.Now.Date;
            TestItem.EmpFullName = "Edward Morra";
            TestItem.EmployeeId = 1;
            TestItem.JobDescriptionPermissions = "Owner";
            TestItem.Salary = 2000.00;
            //adding the item to the test list
            TestList.Add(TestItem);
            //assign the data to the property
            AllStaffMembers.StaffList = TestList;
            //test to see if both values are the same
            Assert.AreEqual(AllStaffMembers.StaffList, TestList);

        }

        [TestMethod]
        public void ThisStaffPropertyOK()
        {
            //creating an instance of the class
            clsStaffCollection AllStaffMembers = new clsStaffCollection();
            //creating test data to assign to the property
            clsStaff TestStaff = new clsStaff();
            //setting the properties for the test object
            TestStaff.Active = true;
            TestStaff.DateHired = DateTime.Now.Date;
            TestStaff.EmpFullName = "Edward Morra";
            TestStaff.EmployeeId = 1;
            TestStaff.JobDescriptionPermissions = "Owner";
            TestStaff.Salary = 2000.00;
            //assign the data to the property
            AllStaffMembers.ThisStaff = TestStaff;
            //testing if both values are equal
            Assert.AreEqual(AllStaffMembers.ThisStaff, TestStaff);

        }

        [TestMethod]
        public void ListAndCountOK()
        {
            //creating an instance of the class
            clsStaffCollection AllStaffMembers = new clsStaffCollection();
            //creating test data to assign to the property
            List<clsStaff> TestList = new List<clsStaff>();
            //adding an item to the list
            //creating the item for the test data
            clsStaff TestItem = new clsStaff();
            //setting the properties for the test object
            TestItem.Active = true;
            TestItem.DateHired = DateTime.Now.Date;
            TestItem.EmpFullName = "Edward Morra";
            TestItem.EmployeeId = 1;
            TestItem.JobDescriptionPermissions = "Owner";
            TestItem.Salary = 2000.00;
            //adding the item to the test list
            TestList.Add(TestItem);
            //assign the data to the property
            AllStaffMembers.StaffList = TestList;
            //testing if both values are equal
            Assert.AreEqual(AllStaffMembers.Count, TestList.Count);

        }

        [TestMethod]

        public void AddMethodOK()
        {
            //creating an instancer of the class
            clsStaffCollection AllStaffMembers = new clsStaffCollection();
            //creating a test item 
            clsStaff TestItem = new clsStaff();
            //variable to store the primary key
            Int32 PrimaryKey = 0;
            // setting the properties of the test item
            TestItem.Active = true;
            TestItem.DateHired = DateTime.Now.Date;
            TestItem.EmpFullName = "Ali Medhat";
            TestItem.EmployeeId = 10;
            TestItem.JobDescriptionPermissions = "Customer Service";
            TestItem.Salary = 2300.00;
            //setting the item as a test data 
            AllStaffMembers.ThisStaff = TestItem;
            //Adding the record 
            PrimaryKey = AllStaffMembers.Add();
            //setting the primary key of the test data
            TestItem.EmployeeId = PrimaryKey;
            //finding the record 
            AllStaffMembers.ThisStaff.Find(PrimaryKey);
            //Testing to see if both values are equal
            Assert.AreEqual(AllStaffMembers.ThisStaff, TestItem);
        }
    

    }
}
