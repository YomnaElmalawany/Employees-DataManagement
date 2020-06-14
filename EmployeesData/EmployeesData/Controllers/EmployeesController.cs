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
        private readonly IEmployeeSkill _employeeSkill;
        private readonly ISkill _skill;

        public EmployeesController(IEmployee employee, IEmployeeSkill employeeSkill, ISkill skill)
        {
            _employee = employee;
            _employeeSkill = employeeSkill;
            _skill = skill;
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
        public IActionResult Create(CreateViewModel createViewModel)
        {
            if (ModelState.IsValid)
            {
                int employeeId =_employee.AddEmpolyee(createViewModel);
                _employeeSkill.AddRecord(employeeId, createViewModel.Skills);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        //Get Skills
        public List<Skill> Skills()
        {
            return _skill.GetSkills();
        }

        // GET: Employees/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = _employee.GetEmployeeById((int)id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        [HttpPost]
        public IActionResult Edit(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _employee.EditEmployee(employee);
                }
                catch (DbUpdateConcurrencyException)
                {
                    //if (_employee.GetEmployeeById(employee.Id) == null)
                    //{
                    return NotFound();
                    //}
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = _employee.GetEmployeeById((int)id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _employee.DeleteEmployee(id);
            _employeeSkill.DeleteRecord(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
