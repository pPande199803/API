using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Model
{
    public class Dbcontext : DbContext
    {
        public Dbcontext(DbContextOptions<Dbcontext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
    }
}
