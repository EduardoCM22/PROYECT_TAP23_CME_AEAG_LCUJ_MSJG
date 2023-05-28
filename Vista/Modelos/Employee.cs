using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; } 
        public string PostalCode { get; set; }
        public int ReportsTo { get; set; }
        public String FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public Employee(int employeeID, String firstName, String lastName,
            String title, String postalCode, int reportsTo)
        {
            EmployeeID = employeeID;
            FirstName = firstName;
            LastName = lastName;
            Title = title;
            PostalCode = postalCode;
            ReportsTo = reportsTo;
        }
    }
}
