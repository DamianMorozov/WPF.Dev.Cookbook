using CH09.EmployeeService.DataModels;
using System.Collections.Generic;
using System.Linq;

namespace CH09.EmployeeService.Services
{
    public class EmployeeService : IEmployeeService
    {
        private static List<Employee> m_employees = new List<Employee>();

        public Employee GetEmployeeByID(string empID)
        {
            return m_employees.First(emp => emp.ID.Equals(empID));
        }

        public List<Employee> GetEmployees()
        {
            return m_employees;
        }

        public void InsertEmployee(Employee employee)
        {
            m_employees.Add(employee);
        }
    }
}
