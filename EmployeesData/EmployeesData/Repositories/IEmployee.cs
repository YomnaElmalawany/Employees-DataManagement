using EmployeesData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesData.Repositories
{
    public interface IEmployee
    {
        int AddEmpolyee(CreateEditViewModel createEditViewModel);
        void DeleteEmployee(int employeeId);
        void EditEmployee(Employee employee);
        List<Employee> GetEmployees();
        Employee GetEmployeeById(int employeeId);
    }
}
