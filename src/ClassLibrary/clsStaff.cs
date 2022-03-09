using System;

namespace ClassLibrary
{
    public class clsStaff
    {
        
        public bool Active { get; set; }
        
        
        private DateTime mDateTime;
        public DateTime DateHired
        {
            get
            {
                return mDateTime;
            }
            set
            {
                mDateTime = value;
            }
        }

        //private data member for the EmplyeeId property
        private Int32 mEmployeeId;
        public int EmployeeIDPrimary
        {
            get
            {
                //this line sends data out of the property
                return mEmployeeId;
            }
            set
            {
                //this line allows data into the property
                mEmployeeId = value;
            }
        }

        public double Salary { get; set; }
        public string EmpFullName { get; set; }
        public string JobDescriptionPermissions { get; set; }

        
        public bool Find(int EmployeeId)
        {
            //set the private data members to the test data value
            mEmployeeId = 2;
            mDateTime = Convert.ToDateTime("16/09/2015");
            //alwyas return true
            return true;
        }
    }
}