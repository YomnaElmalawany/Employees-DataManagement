using EmployeesData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesData.Repositories
{
    public class EmployeeSkillRepo : IEmployeeSkill
    {
        EmployeeDataContext _employeeDataContext;
        public EmployeeSkillRepo(EmployeeDataContext employeeDataContext)
        {
            _employeeDataContext = employeeDataContext;
        }
        public void AddRecord(int employeeId, string skillsString)
        {
            string[] skills = skillsString.Split(',');
            Skill skill = new Skill();
            foreach (var item in skills)
            {
                skill = _employeeDataContext.Skills.FirstOrDefault(s => s.Name == item);
                if (skill != null)
                {
                    _employeeDataContext.EmployeeSkills.Add(new EmployeeSkill()
                    {
                        EmployeeId = employeeId,
                        SkillId = skill.Id
                    });
                }
            }
            _employeeDataContext.SaveChanges();
        }

        void DeleteRecord(int employeeId)
        {
            List<EmployeeSkill> employeeSkills = _employeeDataContext.EmployeeSkills.Where(q => q.EmployeeId == employeeId)
                .ToList();
            _employeeDataContext.EmployeeSkills.RemoveRange(employeeSkills);
            _employeeDataContext.SaveChanges();
        }
    }
}
