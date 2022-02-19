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
        public string Permissions { get; set; }
        public string JobDescription { get; set; }
    }
}