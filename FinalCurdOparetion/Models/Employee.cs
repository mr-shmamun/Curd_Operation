using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalCurdOparetion.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Addrerss { get; set; }
        public string Mobile { get; set; }
    }

    public class EmployeeContext: DbContext
    {
        public DbSet<Employee> employees { get; set; }


        public EmployeeContext(DbContextOptions<EmployeeContext> opt):base(opt)
        {

        }

        public EmployeeContext()
        {

        }
    }
}
