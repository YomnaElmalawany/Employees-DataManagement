using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesData.Models
{
    public class CreateEditViewModel
    {
        public Employee Employee { get; set; }
        public string Skills { get; set; }

        public List<Skill> SkillsList { get; set; } = new List<Skill>()
            {
                new Skill(){ Id = 1, Name = "PHP" },
                new Skill(){ Id = 2, Name = "ASP.NET" },
                new Skill(){ Id = 3, Name = "Android" },
                new Skill(){ Id = 4, Name = "iOS" }
            };
        public List<int> SelectedSkillsList { get; set; }

    }
}
