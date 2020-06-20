using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesData.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Skill>().HasData(
                    new Skill()
                    {
                        Id = 1,
                        Name = "PHP"
                    },
                    new Skill()
                    {
                        Id = 2,
                        Name = "ASP.NET"
                    },
                    new Skill()
                    {
                        Id = 3,
                        Name = "iOS"
                    },
                    new Skill()
                    {
                        Id = 4,
                        Name = "Android"
                    }
                );
        }
    }
}
