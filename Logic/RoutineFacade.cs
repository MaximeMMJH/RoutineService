using RoutineService.Models;
using RoutineService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoutineService.Logic
{
    public class RoutineFacade
    {
        private RoutineRepository repository;

        public RoutineFacade(RoutineRepository routineRepository)
        {
            repository = routineRepository;
        }

        public RoutinePage GetUserRoutines(Guid userId, int pageNumber, int pageSize)
        {
            return repository.GetUserRoutines(userId, pageNumber, pageSize);
        }

        public RoutineDBO GetRoutine(Guid id)
        {
            return repository.GetRoutine(id);
        }

        public void DeleteRoutine(Guid id)
        {
            repository.DeleteRoutine(id);
        }

        public RoutineDBO UpdateRoutine(Guid id, RoutineDBO routine)
        {
            return repository.UpdateRoutine(id, routine);
        }
        public RoutineDBO CreateRoutine(RoutineDBO routine)
        {
            return repository.CreateRoutine(routine);
        }

        public void CountCompletion(Guid id)
        {
            repository.CountCompletion(id);
        }
    }
}
