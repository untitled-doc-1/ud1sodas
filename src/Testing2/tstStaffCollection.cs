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

        [TestMethod]
        public void UpdateMethod()
        {
            //creating an instance of the class 
            clsStaffCollection AllStaffMembers = new clsStaffCollection();
            //creating the item for testing
            clsStaff TestItem = new clsStaff();
            //variable to store the primary key
            Int32 PrimaryKey = 0;
            //Setting the properties for the item
            TestItem.Active = true;
            TestItem.DateHired = DateTime.Now.Date;
            TestItem.EmpFullName = "Hadel Medhat";
            TestItem.EmployeeId = 16;
            TestItem.JobDescriptionPermissions = "Customer Service";
            TestItem.Salary = 2300.00;
            //setting this staff to the test data 
            AllStaffMembers.ThisStaff = TestItem;
            //adding the record
            PrimaryKey = AllStaffMembers.Add();
            //setting the primary key of the test data 
            TestItem.EmployeeId = PrimaryKey;
            //modifying the test data
            TestItem.Active = false;
            TestItem.DateHired = DateTime.Now.Date;
            TestItem.EmpFullName = "Louise Nilsen";
            TestItem.EmployeeId = 16;
            TestItem.JobDescriptionPermissions = "Customer Service";
            TestItem.Salary = 2600.00;
            //setting the record based on the new test data 
            AllStaffMembers.ThisStaff = TestItem;
            //updating the record
            AllStaffMembers.Update();
            //finding the record 
            AllStaffMembers.ThisStaff.Find(PrimaryKey);
            //Testing to see if thisStaff matches the test data
            Assert.AreEqual(AllStaffMembers.ThisStaff, TestItem);
        }

        [TestMethod]
        public void DeleteMethodOK()
        {
            //creating an instance of the class
            clsStaffCollection AllStaffMembers = new clsStaffCollection();
            //creating a test Item
            clsStaff TestItem = new clsStaff();
            //A variable to store the primary key
            Int32 PrimaryKey = 0;
            //setting test item's properties
            TestItem.Active = false;
            TestItem.DateHired = DateTime.Now.Date;
            TestItem.EmpFullName = "Camilla Takagi";
            TestItem.EmployeeId = 16;
            TestItem.JobDescriptionPermissions = "Customer Service";
            TestItem.Salary = 2600.00;
            //Setting thisStaff to the test data
            AllStaffMembers.ThisStaff = TestItem;
            //adding the record 
            PrimaryKey = AllStaffMembers.Add();
            //setting the primary key of the test data
            TestItem.EmployeeId = PrimaryKey;
            //finding the record
            AllStaffMembers.ThisStaff.Find(PrimaryKey);
            //deleting the record
            AllStaffMembers.Delete();
            //now try finding the record again
            Boolean Found = AllStaffMembers.ThisStaff.Find(PrimaryKey);
            //testing to see if the record is not found
            Assert.IsFalse(Found);
        }

        [TestMethod]
        public void ReportByEmpFullNameMethodeOK()
        {
            //creating an instance of the class 
            clsStaffCollection AllStaffMembers = new clsStaffCollection();
            //creating an instance of the filtered data
            clsStaffCollection FilteredStaffMembers = new clsStaffCollection();
            //applying a blank string (should return all records);
            FilteredStaffMembers.ReportByEmpFullName("");
            //testing to see that both values are the same
            Assert.AreEqual(AllStaffMembers.Count, FilteredStaffMembers.Count);
        }

        [TestMethod]
        public void ReportByEmpFullNameNoneFound()
        {
            //creating an instance of the filtered data
            clsStaffCollection FilteredStaffMembers = new clsStaffCollection();
            //applying an employee name that doesn't exist
            FilteredStaffMembers.ReportByEmpFullName("lalal");
            //testing to see that there are no such record
            Assert.AreEqual(0, FilteredStaffMembers.Count);
        }

        [TestMethod]
        public void ReportByEmpFullNameTestDataFound()
        {
            //creating an instance of the filtered data
            clsStaffCollection FilteredStaffMembers = new clsStaffCollection();
            //variable to store outcome
            Boolean OK = true;
            //applying an employee full name that dosen't exist
            FilteredStaffMembers.ReportByEmpFullName("Sara Eizeddin");
            //checking if the correct number of records are found 
            if (FilteredStaffMembers.Count == 2)
            {
                //cheking that the first record is ID 36
                if (FilteredStaffMembers.StaffList[0].EmployeeId != 11)
                {
                    OK = false;
                }

                //checking that the first record is ID 37
                if (FilteredStaffMembers.StaffList[1].EmployeeId != 51)
                {
                    OK = false;
                }
            }
            else
            {
                OK = false;
            }
            //testing to see that there are no records
            Assert.IsTrue(OK);
        }


        [TestMethod]
        public void ReportJobDescriptionPermissions()
        {
            //creating an instance of the class 
            clsStaffCollection AllStaffMembers = new clsStaffCollection();
            //creating an instance of the filtered data
            clsStaffCollection FilteredStaffMembers = new clsStaffCollection();
            //applying a blank string (should return all records);
            FilteredStaffMembers.ReportJobDescriptionPermissions("");
            //testing to see that both values are the same
            Assert.AreEqual(AllStaffMembers.Count, FilteredStaffMembers.Count);
        }

        [TestMethod]
        public void ReportJobDescriptionPermissionsNoneFound()
        {
            //creating an instance of the filtered data
            clsStaffCollection FilteredStaffMembers = new clsStaffCollection();
            //applying an employee name that doesn't exist
            FilteredStaffMembers.ReportJobDescriptionPermissions("lalal");
            //testing to see that there are no such record
            Assert.AreEqual(0, FilteredStaffMembers.Count);
        }

        [TestMethod]
        public void ReportJobDescriptionPermissionsTestDataFound()
        {
            //creating an instance of the filtered data
            clsStaffCollection FilteredStaffMembers = new clsStaffCollection();
            //variable to store outcome
            Boolean OK = true;
            //applying an employee full name that dosen't exist
            FilteredStaffMembers.ReportJobDescriptionPermissions("Marketing");
            //checking if the correct number of records are found 
            if (FilteredStaffMembers.Count == 2)
            {
                //cheking that the first record is ID 36
                if (FilteredStaffMembers.StaffList[0].EmployeeId != 2)
                {
                    OK = false;
                }

                //checking that the first record is ID 37
                if (FilteredStaffMembers.StaffList[1].EmployeeId != 3)
                {
                    OK = false;
                }
            }
            else
            {
                OK = false;
            }
            //testing to see that there are no records
            Assert.IsTrue(OK);
        }


    }
}
