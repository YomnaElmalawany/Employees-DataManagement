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
        
        public void AddRecord(int employeeId, List<int> selectedSkills)
        {
            foreach (var item in selectedSkills)
            {
                _employeeDataContext.EmployeeSkills.Add(new EmployeeSkill()
                {
                    EmployeeId = employeeId,
                    SkillId = item
                });
            }
            _employeeDataContext.SaveChanges();
        }

        public void DeleteRecord(int employeeId)
        {
            List<EmployeeSkill> employeeSkills = _employeeDataContext.EmployeeSkills.Where(q => q.EmployeeId == employeeId)
                .ToList();
            _employeeDataContext.EmployeeSkills.RemoveRange(employeeSkills);
            _employeeDataContext.SaveChanges();
        }

        public List<int> GetSkillsByEmployeeId(int employeeId)
        {
            List<EmployeeSkill> employeeSkills = _employeeDataContext.EmployeeSkills.Where(e => e.EmployeeId == employeeId)
                .ToList();
            List<Skill> skills = new List<Skill>();
            List<int> skillsIds = new List<int>();
            foreach (var item in employeeSkills)
            {
                skillsIds.Add(_employeeDataContext.Skills.SingleOrDefault(s => s.Id == item.SkillId).Id);
            }
            return skillsIds;
        }

        public void EditRecord(CreateEditViewModel createEditViewModel)
        {
            List<EmployeeSkill> employeeSkills = _employeeDataContext.EmployeeSkills.Where(e => e.EmployeeId ==
            createEditViewModel.Employee.Id).ToList();
            _employeeDataContext.EmployeeSkills.RemoveRange(employeeSkills);
            if(createEditViewModel.SelectedSkillsList != null)
            {
                foreach (var item in createEditViewModel.SelectedSkillsList)
                {
                    _employeeDataContext.EmployeeSkills.Add(new EmployeeSkill()
                    {
                        EmployeeId = createEditViewModel.Employee.Id,
                        SkillId = item
                    });
                }
            }
            
            _employeeDataContext.SaveChanges();
        }
    }
}
