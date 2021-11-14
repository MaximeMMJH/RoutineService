using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoutineService.Models
{
    public class RoutineQM
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int TimesCompleted { get; set; }
        public Guid UserId { get; set; }
        public List<Guid> ExerciseIds { get; set; }
    }
}
