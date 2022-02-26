using System;

namespace ClassLibrary
{
    public class clsStaff
    {
        public bool Active { get; set; }
        public DateTime DateHired { get; set; }
        public int EmployeeIDPrimary { get; set; }
        public double Salary { get; set; }
        public string EmpFullName { get; set; }
        public string JobDescriptionPermissions { get; set; }

        public bool Search(int employeeId)
        {
            throw new NotImplementedException();
        }
    }
}