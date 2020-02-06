using CH09.EmployeeService.DataModels;
using System.Collections.Generic;
using System.ServiceModel;

namespace CH09.EmployeeService.Services
{
    [ServiceContract]
    public interface IEmployeeService
    {
        [OperationContract]
        Employee GetEmployeeByID(string empID);

        [OperationContract]
        List<Employee> GetEmployees();

        [OperationContract]
        void InsertEmployee(Employee employee);
    }
}
