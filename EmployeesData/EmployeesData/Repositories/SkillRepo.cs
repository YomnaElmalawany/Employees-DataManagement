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
        public List<Skill> GetSkillsByEmployeeId(int employeeId)
        {
            List<EmployeeSkill> employeeSkill = _employeeDataContext.EmployeeSkills.
                Where(e => e.EmployeeId == employeeId).ToList();
            List<Skill> skills = new List<Skill>();
            foreach (var item in employeeSkill)
            {
                skills.Add(_employeeDataContext.Skills.FirstOrDefault(s => s.Id == item.SkillId));
            }
            return skills;
        }
    }
}
