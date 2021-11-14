using Microsoft.EntityFrameworkCore;
using RoutineService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoutineService.Repositories
{
    public class RoutineDbContext : DbContext
    {
        public RoutineDbContext(DbContextOptions<RoutineDbContext> options) : base(options)
        {

        }

        public DbSet<RoutineDBO> Routines { get; set; }
    }
}
