using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeesData.Models;
using EmployeesData.Repositories;

namespace EmployeesData.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployee _employee;

        public EmployeesController(IEmployee employee)
        {
            _employee = employee;
        }

        // GET: Employees
        public IActionResult Index()
        {
            return View(_employee.GetEmployees());
        }
        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employee.AddEmpolyee(employee);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

    }
}
