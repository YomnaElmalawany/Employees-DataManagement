using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesData.Models
{
    public class EmployeeSkill
    {
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        [ForeignKey("Skill")]
        public int SkillId { get; set; }
        public Employee Employee { get; set; }
        public Skill Skill { get; set; }
    }
}
