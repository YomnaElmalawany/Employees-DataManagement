﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesData.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public List<EmployeeSkill> EmployeeSkills { get; set; }
    }
}
