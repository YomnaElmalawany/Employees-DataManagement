﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesData.Models
{
    public class EditViewModel
    {
        public Employee Employee { get; set; }
        public List<Skill> Skills { get; set; }
        public string SkillsString { get; set; }
    }
}
