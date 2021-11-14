using RoutineService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoutineService.Mappers
{
    public class RoutineMapper
    {
        public static RoutinePageResponse MapToRoutinePageResponse(RoutinePage page)
        {
            return new RoutinePageResponse()
            {
                items = MapToRoutineQMs(page.items),
                TotalPages = page.TotalPages,
                TotalElements = page.TotalElements
            };
        }
        public static RoutineDBO MapToRoutineDTO(RoutineQM routineQM)
        {
            return new RoutineDBO()
            {
                Id = routineQM.Id,
                Title = routineQM.Title,
                Description = routineQM.Description,
                TimesCompleted = routineQM.TimesCompleted,
                UserId = routineQM.UserId,
                ExerciseIds = routineQM.ExerciseIds
            };
        }

        public static RoutineQM MapToRoutineQM(RoutineDBO routineDTO)
        {
            return new RoutineQM()
            {
                Id = routineDTO.Id,
                Title = routineDTO.Title,
                Description = routineDTO.Description,
                TimesCompleted = routineDTO.TimesCompleted,
                UserId = routineDTO.UserId,
                ExerciseIds = routineDTO.ExerciseIds
            };
        }

        public static List<RoutineDBO> MapToRoutineDTOs(List<RoutineQM> routineQMs)
        {
            return routineQMs.Select(routineQM => MapToRoutineDTO(routineQM)).ToList();
        }

        public static List<RoutineQM> MapToRoutineQMs(List<RoutineDBO> routineDTOs)
        {
            return routineDTOs.Select(routineDTO => MapToRoutineQM(routineDTO)).ToList();
        }
    }
}
