using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoutineService.Models
{
    public class RoutinePageResponse
    {
        public List<RoutineQM> items { get; set; }
        public int TotalPages { get; set; }
        public int TotalElements { get; set; }
    }
}
