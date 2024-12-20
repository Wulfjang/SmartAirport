using System.Collections.Generic;
using System.Linq;

namespace SmartAirport.Services
{
    public class EmployeeService
    {
        private List<Employee> employees = new List<Employee>
        {
        };

        public List<Employee> GetAllEmployees()
        {
            return employees;
        }

        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
        }

        public void RemoveEmployee(string employeeID)
        {
            var employee = employees.FirstOrDefault(e => e.EmployeeID == employeeID);
            if (employee != null) employees.Remove(employee);
        }

        public Employee FindEmployeeByName(string name)
        {
            return employees.FirstOrDefault(e => e.Name.ToLower().Contains(name.ToLower()));
        }
    }
}