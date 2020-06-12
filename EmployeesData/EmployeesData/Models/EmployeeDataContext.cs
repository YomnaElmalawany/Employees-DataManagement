using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesData.Models
{
    public class EmployeeDataContext:DbContext
    {
        public EmployeeDataContext(DbContextOptions<EmployeeDataContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<EmployeeSkill> EmployeeSkills { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // set composite key in EmployeeSkills table
            modelBuilder.Entity<EmployeeSkill>()
                .HasKey(k => new { k.EmployeeId, k.SkillId });

            // Seed data in Skills table
            modelBuilder.Seed();
        }
    }
}
