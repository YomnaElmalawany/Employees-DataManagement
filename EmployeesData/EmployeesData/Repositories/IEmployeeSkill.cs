using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesData.Repositories
{
    public interface IEmployeeSkill
    {
        void AddRecord(int employeeId, string skills);
        void DeleteRecord(int employeeId);
    }
}
