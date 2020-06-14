using EmployeesData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesData.Repositories
{
    public class SkillRepo : ISkill
    {
        EmployeeDataContext _employeeDataContext;
        public SkillRepo(EmployeeDataContext employeeDataContext)
        {
            _employeeDataContext = employeeDataContext;
        }
        public List<Skill> GetSkills()
        {
            return _employeeDataContext.Skills.ToList();
        }
    }
}
