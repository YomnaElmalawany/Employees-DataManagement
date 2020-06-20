using EmployeesData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesData.Repositories
{
    public interface IEmployeeSkill
    {
        void AddRecord(int employeeId, List<int> selectedSkills);
        void DeleteRecord(int employeeId);
        List<int> GetSkillsByEmployeeId(int employeeId);
        void EditRecord(CreateEditViewModel createEditViewModel);
    }
}
