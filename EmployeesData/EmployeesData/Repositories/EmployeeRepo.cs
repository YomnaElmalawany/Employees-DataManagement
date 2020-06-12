using EmployeesData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesData.Repositories
{
    public class EmployeeRepo : IEmployee
    {
        EmployeeDataContext _employeeDataContext;
        public EmployeeRepo(EmployeeDataContext employeeDataContext)
        {
            _employeeDataContext = employeeDataContext;
        }
        public int AddEmpolyee(CreateViewModel createViewModel)
        {
            _employeeDataContext.Employees.Add(createViewModel.Employee);

            _employeeDataContext.SaveChanges();

            int id = createViewModel.Employee.Id;
            return id;
        }

        public void DeleteEmployee(int employeeId)
        {
            Employee employee = _employeeDataContext.Employees.SingleOrDefault(e => e.Id == employeeId);
            _employeeDataContext.Employees.Remove(employee);
            _employeeDataContext.SaveChanges();
        }

        public void EditEmployee(Employee employee)
        {
            _employeeDataContext.Entry<Employee>(employee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _employeeDataContext.SaveChanges();
        }

        public List<Employee> GetEmployees()
        {
            return _employeeDataContext.Employees.ToList();
        }
        public Employee GetEmployeeById(int employeeId)
        {
            return _employeeDataContext.Employees.SingleOrDefault(e => e.Id == employeeId);
        }
    }
}
