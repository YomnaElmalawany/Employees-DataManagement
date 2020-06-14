using EmployeesData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesData.Repositories
{
    public interface ISkill
    {
        List<Skill> GetSkills();
        List<Skill> GetSkillsByEmployeeId(int employeeId);
    }
}
