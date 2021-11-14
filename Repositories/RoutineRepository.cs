using Microsoft.EntityFrameworkCore.ChangeTracking;
using RoutineService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoutineService.Repositories
{
    public class RoutineRepository
    {
        private RoutineDbContext dbContext;
        public RoutineRepository(RoutineDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public RoutinePage GetUserRoutines(Guid userId, int pageNumber, int pageSize)
        {
            int totalElements = dbContext.Routines
                .Where(routine => routine.UserId.Equals(userId))
                .Count();
            int totalPages = totalElements / pageSize;

            return new RoutinePage()
            {
                items = dbContext.Routines
                    .Where(routine => routine.UserId.Equals(userId))
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToList(),
                TotalElements = totalElements,
                TotalPages = totalElements % pageSize == 0 ? totalPages : totalPages + 1
            };
        }

        public RoutineDBO GetRoutine(Guid id)
        {
            return dbContext.Routines.Find(id);
        }

        public RoutineDBO CreateRoutine(RoutineDBO routine)
        {
            EntityEntry<RoutineDBO> entityEntry = dbContext.Routines.Add(routine);
            dbContext.SaveChanges();
            return entityEntry.Entity;
        }

        public void DeleteRoutine(Guid id)
        {
            dbContext.Remove(dbContext.Routines.Single(a => a.Id == id));
            dbContext.SaveChanges();
        }

        public RoutineDBO UpdateRoutine(Guid id, RoutineDBO routine)
        {
            EntityEntry<RoutineDBO> entityEntry = dbContext.Routines.Update(routine);
            dbContext.SaveChanges();
            return entityEntry.Entity;
        }

        internal void CountCompletion(Guid id)
        {
            dbContext.Routines.First(routine => routine.Id.Equals(id)).TimesCompleted++;
            dbContext.SaveChanges();
        }
    }
}
